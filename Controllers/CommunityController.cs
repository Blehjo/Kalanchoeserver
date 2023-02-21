using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KalanchoeAI_Backend.Data;
using KalanchoeAI_Backend.Models;

namespace KalanchoeAI_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunityController : ControllerBase
    {
        private readonly KalanchoeAIDatabaseContext _context;

        public CommunityController(KalanchoeAIDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Community
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Community>>> GetCommunities()
        {
          if (_context.Communities == null)
          {
              return NotFound();
          }
            return await _context.Communities.ToListAsync();
        }

        // GET: api/Community/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Community>> GetCommunity(int id)
        {
          if (_context.Communities == null)
          {
              return NotFound();
          }
            var community = await _context.Communities.FindAsync(id);

            if (community == null)
            {
                return NotFound();
            }

            return community;
        }

        // PUT: api/Community/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommunity(int id, Community community)
        {
            if (id != community.CommunityId)
            {
                return BadRequest();
            }

            _context.Entry(community).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommunityExists(id))
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

        // POST: api/Community
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Community>> PostCommunity(Community community)
        {
          if (_context.Communities == null)
          {
              return Problem("Entity set 'KalanchoeAIDatabaseContext.Communities'  is null.");
          }

            community.UserId = Int32.Parse(HttpContext.Request.Cookies["user"]);
            _context.Communities.Add(community);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommunity", new { id = community.CommunityId }, community);
        }

        // DELETE: api/Community/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommunity(int id)
        {
            if (_context.Communities == null)
            {
                return NotFound();
            }
            var community = await _context.Communities.FindAsync(id);
            if (community == null)
            {
                return NotFound();
            }

            _context.Communities.Remove(community);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommunityExists(int id)
        {
            return (_context.Communities?.Any(e => e.CommunityId == id)).GetValueOrDefault();
        }
    }
}
