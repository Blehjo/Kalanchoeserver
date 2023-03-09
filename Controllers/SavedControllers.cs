using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KalanchoeAI_Backend.Data;
using KalanchoeAI_Backend.Models;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Hosting;

namespace KalanchoeAI_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SavedControllers : ControllerBase
    {
        private readonly KalanchoeAIDatabaseContext _context;

        public SavedControllers(KalanchoeAIDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/SavedControllers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Saved>>> GetSaved()
        {
          if (_context.Saved == null)
          {
              return NotFound();
          }
            return await _context.Saved.ToListAsync();
        }

        // GET: api/SavedControllers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Saved>> GetSaved(int id)
        {
          if (_context.Saved == null)
          {
              return NotFound();
          }
            var saved = await _context.Saved.FindAsync(id);

            if (saved == null)
            {
                return NotFound();
            }

            return saved;
        }

        [HttpGet("user")]
        public async Task<ActionResult<IEnumerable<Saved>>> GetSingleUserSaved()
        {
            if (_context.Saved == null)
            {
                return NotFound();
            }
            int id = Int32.Parse(HttpContext.Request.Cookies["user"]);
            return await _context.Saved.Where(s => s.UserId == id).ToListAsync();
        }

        // PUT: api/SavedControllers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSaved(int id, Saved saved)
        {
            if (id != saved.SavedId)
            {
                return BadRequest();
            }

            _context.Entry(saved).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SavedExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SavedControllers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Saved>> PostSaved(Saved saved)
        {
          if (_context.Saved == null)
          {
              return Problem("Entity set 'KalanchoeAIDatabaseContext.Saved'  is null.");
          }

            if (saved.MediaLink != null)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "_" + String.Format("{0:d}", (DateTime.Now.Ticks / 10) % 100000000) + saved.MediaLink.FileName);

                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    saved.MediaLink.CopyTo(stream);
                }
            }

            saved.UserId = Int32.Parse(HttpContext.Request.Cookies["user"]);
            _context.Saved.Add(saved);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSaved", new { id = saved.SavedId }, saved);
        }

        // DELETE: api/SavedControllers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSaved(int id)
        {
            if (_context.Saved == null)
            {
                return NotFound();
            }
            var saved = await _context.Saved.FindAsync(id);
            if (saved == null)
            {
                return NotFound();
            }

            _context.Saved.Remove(saved);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SavedExists(int id)
        {
            return (_context.Saved?.Any(e => e.SavedId == id)).GetValueOrDefault();
        }
    }
}
