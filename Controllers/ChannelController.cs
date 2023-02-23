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
    public class ChannelController : ControllerBase
    {
        private readonly KalanchoeAIDatabaseContext _context;

        public ChannelController(KalanchoeAIDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Channel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Channel>>> GetChannels()
        {
          if (_context.Channels == null)
          {
              return NotFound();
          }
            return await _context.Channels.ToListAsync();
        }

        // GET: api/Channel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Channel>> GetChannel(int id)
        {
          if (_context.Channels == null)
          {
              return NotFound();
          }
            var channel = await _context.Channels.FindAsync(id);

            if (channel == null)
            {
                return NotFound();
            }

            return channel;
        }

        [HttpGet("community/{id}")]
        public async Task<ActionResult<IEnumerable<Channel>>> GetSingleCommunityChannels(int id)
        {
            if (_context.Channels == null)
            {
                return NotFound();
            }

            return await _context.Channels.Where(c => c.CommunityId == id).ToListAsync();
        }

        // PUT: api/Channel/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChannel(int id, Channel channel)
        {
            if (id != channel.ChannelId)
            {
                return BadRequest();
            }

            _context.Entry(channel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChannelExists(id))
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

        // POST: api/Channel
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Channel>> PostChannel(Channel channel)
        {
          if (_context.Channels == null)
          {
              return Problem("Entity set 'KalanchoeAIDatabaseContext.Channels'  is null.");
          }
            _context.Channels.Add(channel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChannel", new { id = channel.ChannelId }, channel);
        }

        // DELETE: api/Channel/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChannel(int id)
        {
            if (_context.Channels == null)
            {
                return NotFound();
            }
            var channel = await _context.Channels.FindAsync(id);
            if (channel == null)
            {
                return NotFound();
            }

            _context.Channels.Remove(channel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChannelExists(int id)
        {
            return (_context.Channels?.Any(e => e.ChannelId == id)).GetValueOrDefault();
        }
    }
}
