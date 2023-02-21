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
    public class ChatController : ControllerBase
    {
        private readonly KalanchoeAIDatabaseContext _context;

        public ChatController(KalanchoeAIDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Chat
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chat>>> GetChats()
        {
          if (_context.Chats == null)
          {
              return NotFound();
          }
            return await _context.Chats.ToListAsync();
        }

        [HttpGet("user")]
        public async Task<ActionResult<IEnumerable<Chat>>> GetUserChats()
        {
            if (_context.Chats == null)
            {
                return NotFound();
            }
            var userId = Int32.Parse(HttpContext.Request.Cookies["user"]);

            return await _context.Chats.Where(c => c.UserId == userId).ToListAsync();
        }

        [HttpGet("user/{id}")]
        public async Task<ActionResult<IEnumerable<Chat>>> GetSingleUserChats(int id)
        {
            if (_context.Chats == null)
            {
                return NotFound();
            }

            return await _context.Chats.Where(c => c.UserId == id).ToListAsync();
        }

        // GET: api/Chat/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Chat>> GetChat(int id)
        {
          if (_context.Chats == null)
          {
              return NotFound();
          }
            var chat = await _context.Chats.FindAsync(id);

            if (chat == null)
            {
                return NotFound();
            }

            return chat;
        }

        // PUT: api/Chat/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChat(int id, Chat chat)
        {
            if (id != chat.ChatId)
            {
                return BadRequest();
            }

            _context.Entry(chat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatExists(id))
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

        // POST: api/Chat
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Chat>> PostChat(Chat chat)
        {
          if (_context.Chats == null)
          {
              return Problem("Entity set 'KalanchoeAIDatabaseContext.Chats'  is null.");
          }
            chat.UserId = Int32.Parse(HttpContext.Request.Cookies["user"]);
            _context.Chats.Add(chat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChat", new { id = chat.ChatId }, chat);
        }

        // DELETE: api/Chat/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChat(int id)
        {
            if (_context.Chats == null)
            {
                return NotFound();
            }
            var chat = await _context.Chats.FindAsync(id);
            if (chat == null)
            {
                return NotFound();
            }

            _context.Chats.Remove(chat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChatExists(int id)
        {
            return (_context.Chats?.Any(e => e.ChatId == id)).GetValueOrDefault();
        }
    }
}
