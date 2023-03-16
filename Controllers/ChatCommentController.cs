using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KalanchoeAI_Backend.Data;
using KalanchoeAI_Backend.Models;

namespace KalanchoeAI_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatCommentController : ControllerBase
    {

        private readonly KalanchoeAIDatabaseContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ChatCommentController(KalanchoeAIDatabaseContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: api/ChatComment
        [HttpGet("user/{id}")]
        public async Task<ActionResult<IEnumerable<ChatComment>>> GetUserChatComments(int id)
        {
          if (_context.ChatComments == null)
          {
              return NotFound();
          }
            return await _context.ChatComments.Where(c => c.ChatId == id).Select(x => new ChatComment()
            {
                ChatCommentId = x.ChatCommentId,
                ChatValue = x.ChatValue,
                DateCreated = x.DateCreated,
                ImageSource = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, x.ChatValue)
            }).ToListAsync();
        }

        // GET: api/ChatComment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChatComment>>> GetChatComments()
        {
            if (_context.ChatComments == null)
            {
                return NotFound();
            }
            return await _context.ChatComments.Select(x => new ChatComment()
            {
                ChatCommentId = x.ChatCommentId,
                ChatValue = x.ChatValue,
                DateCreated = x.DateCreated,
                ImageSource = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, x.ChatValue)
            }).ToListAsync();
        }

        // GET: api/ChatComment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChatComment>> GetChatComment(int id)
        {
          if (_context.ChatComments == null)
          {
              return NotFound();
          }
            var chatComment = await _context.ChatComments.FindAsync(id);

            if (chatComment == null)
            {
                return NotFound();
            }

            return chatComment;
        }

        // PUT: api/ChatComment/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChatComment(int id, ChatComment chatComment)
        {
            if (id != chatComment.ChatCommentId)
            {
                return BadRequest();
            }

            _context.Entry(chatComment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatCommentExists(id))
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

        // POST: api/ChatComment
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChatComment>> PostChatComment(ChatComment chatComment)
        {
            if (_context.ChatComments == null)
            {
              return Problem("Entity set 'KalanchoeAIDatabaseContext.ChatComments'  is null.");
            }

            if (chatComment.ImageFile != null)
            {
                chatComment.ChatValue = await SaveImage(chatComment.ImageFile);
            }

            _context.ChatComments.Add(chatComment);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChatComment", new { id = chatComment.ChatCommentId }, chatComment);
        }

        // DELETE: api/ChatComment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChatComment(int id)
        {
            if (_context.ChatComments == null)
            {
                return NotFound();
            }
            var chatComment = await _context.ChatComments.FindAsync(id);
            if (chatComment == null)
            {
                return NotFound();
            }

            _context.ChatComments.Remove(chatComment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChatCommentExists(int id)
        {
            return (_context.ChatComments?.Any(e => e.ChatCommentId == id)).GetValueOrDefault();
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
