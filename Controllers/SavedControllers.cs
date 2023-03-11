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
        private readonly IWebHostEnvironment _hostEnvironment;

        public SavedControllers(KalanchoeAIDatabaseContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: api/SavedControllers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Saved>>> GetSaved()
        {
            if (_context.Saved == null)
            {
                return NotFound();
            }
            
            return await _context.Saved.Select(x => new Saved() {
                SavedId = x.SavedId,
                Title = x.Title,
                Link = x.Link,
                MediaLink = x.MediaLink,
                DateCreated = x.DateCreated,
                ImageSource = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, x.MediaLink)}).ToListAsync();
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

            saved.ImageSource = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, saved.MediaLink);

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

            return await _context.Saved.Where(c => c.UserId == id).Select(x => new Saved()
            {
                SavedId = x.SavedId,
                Title = x.Title,
                Link = x.Link,
                MediaLink = x.MediaLink,
                DateCreated = x.DateCreated,
                ImageSource = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, x.MediaLink)
            }).ToListAsync();
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

            if (saved.ImageFile != null)
            {
                saved.MediaLink = await SaveImage(saved.ImageFile);
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

        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return imageName;
        }

        [NonAction]
        public void DeleteImage(string imageName)
        {
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
        }
    }
}
