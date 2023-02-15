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
    public class ChannelCommentController : ControllerBase
    {
        private readonly KalanchoeAIDatabaseContext _context;

        public ChannelCommentController(KalanchoeAIDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/ChannelComment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChannelComment>>> GetChannelComments()
        {
          if (_context.ChannelComments == null)
          {
              return NotFound();
          }
            return await _context.ChannelComments.ToListAsync();
        }

        // GET: api/ChannelComment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChannelComment>> GetChannelComment(int id)
        {
          if (_context.ChannelComments == null)
          {
              return NotFound();
          }
            var channelComment = await _context.ChannelComments.FindAsync(id);

            if (channelComment == null)
            {
                return NotFound();
            }

            return channelComment;
        }

        // PUT: api/ChannelComment/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChannelComment(int id, ChannelComment channelComment)
        {
            if (id != channelComment.ChannelCommentId)
            {
                return BadRequest();
            }

            _context.Entry(channelComment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChannelCommentExists(id))
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

        // POST: api/ChannelComment
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChannelComment>> PostChannelComment(ChannelComment channelComment)
        {
          if (_context.ChannelComments == null)
          {
              return Problem("Entity set 'KalanchoeAIDatabaseContext.ChannelComments'  is null.");
          }
            _context.ChannelComments.Add(channelComment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChannelComment", new { id = channelComment.ChannelCommentId }, channelComment);
        }

        // DELETE: api/ChannelComment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChannelComment(int id)
        {
            if (_context.ChannelComments == null)
            {
                return NotFound();
            }
            var channelComment = await _context.ChannelComments.FindAsync(id);
            if (channelComment == null)
            {
                return NotFound();
            }

            _context.ChannelComments.Remove(channelComment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChannelCommentExists(int id)
        {
            return (_context.ChannelComments?.Any(e => e.ChannelCommentId == id)).GetValueOrDefault();
        }
    }
}
