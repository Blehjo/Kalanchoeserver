using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KalanchoeAI.Data;
using KalanchoeAI.Models;

namespace KalanchoeAI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowerController : ControllerBase
    {
        private readonly KalanchoeAIDatabaseContext _context;

        public FollowerController(KalanchoeAIDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Follower
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Follower>>> GetFollowers()
        {
          if (_context.Followers == null)
          {
              return NotFound();
          }
            return await _context.Followers.ToListAsync();
        }

        // GET: api/Follower/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Follower>> GetFollower(int? id)
        {
          if (_context.Followers == null)
          {
              return NotFound();
          }
            var follower = await _context.Followers.FindAsync(id);

            if (follower == null)
            {
                return NotFound();
            }

            return follower;
        }

        // PUT: api/Follower/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFollower(int? id, Follower follower)
        {
            if (id != follower.FollowerId)
            {
                return BadRequest();
            }

            _context.Entry(follower).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FollowerExists(id))
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

        // POST: api/Follower
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Follower>> PostFollower(Follower follower)
        {
          if (_context.Followers == null)
          {
              return Problem("Entity set 'KalanchoeAIDatabaseContext.Followers'  is null.");
          }
            _context.Followers.Add(follower);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFollower", new { id = follower.FollowerId }, follower);
        }

        // DELETE: api/Follower/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFollower(int? id)
        {
            if (_context.Followers == null)
            {
                return NotFound();
            }
            var follower = await _context.Followers.FindAsync(id);
            if (follower == null)
            {
                return NotFound();
            }

            _context.Followers.Remove(follower);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FollowerExists(int? id)
        {
            return (_context.Followers?.Any(e => e.FollowerId == id)).GetValueOrDefault();
        }
    }
}
