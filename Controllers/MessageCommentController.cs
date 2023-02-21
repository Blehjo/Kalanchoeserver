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
    public class MessageCommentController : ControllerBase
    {
        private readonly KalanchoeAIDatabaseContext _context;

        public MessageCommentController(KalanchoeAIDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/MessageComment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MessageComment>>> GetMessageComments()
        {
          if (_context.MessageComments == null)
          {
              return NotFound();
          }
            return await _context.MessageComments.ToListAsync();
        }

        // GET: api/MessageComment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<MessageComment>>> GetMessageComment(int id)
        {
          if (_context.MessageComments == null)
          {
              return NotFound();
          }
            return await _context.MessageComments.Where(m => m.MessageId == id).ToListAsync();
        }

        // PUT: api/MessageComment/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMessageComment(int id, MessageComment messageComment)
        {
            if (id != messageComment.MessageCommentId)
            {
                return BadRequest();
            }

            _context.Entry(messageComment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessageCommentExists(id))
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

        // POST: api/MessageComment
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MessageComment>> PostMessageComment(MessageComment messageComment)
        {
          if (_context.MessageComments == null)
          {
              return Problem("Entity set 'KalanchoeAIDatabaseContext.MessageComments'  is null.");
          }
            _context.MessageComments.Add(messageComment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMessageComment", new { id = messageComment.MessageCommentId }, messageComment);
        }

        // DELETE: api/MessageComment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessageComment(int id)
        {
            if (_context.MessageComments == null)
            {
                return NotFound();
            }
            var messageComment = await _context.MessageComments.FindAsync(id);
            if (messageComment == null)
            {
                return NotFound();
            }

            _context.MessageComments.Remove(messageComment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MessageCommentExists(int id)
        {
            return (_context.MessageComments?.Any(e => e.MessageCommentId == id)).GetValueOrDefault();
        }
    }
}
