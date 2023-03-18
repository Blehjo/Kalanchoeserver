using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KalanchoeAI_Backend.Data;
using KalanchoeAI_Backend.Models;

namespace KalanchoeAI_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AiCommentController : ControllerBase
    {

        private readonly KalanchoeAIDatabaseContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AiCommentController(KalanchoeAIDatabaseContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: api/AiComment
        [HttpGet("user/{id}")]
        public async Task<ActionResult<IEnumerable<AiComment>>> GetUserAiComments(int id)
        {
            if (_context.AiComments == null)
            {
                return NotFound();
            }
            return await _context.AiComments.Where(c => c.ChatId == id).Select(x => new AiComment()
            {
                AiCommentId = x.AiCommentId,
                CommentValue = x.CommentValue,
                DateCreated = x.DateCreated,
                ImageSource = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, x.CommentValue)
            }).ToListAsync();
        }

        // GET: api/AiComment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AiComment>>> GetAiComments()
        {
            if (_context.AiComments == null)
            {
                return NotFound();
            }
            return await _context.AiComments.Select(x => new AiComment()
            {
                AiCommentId = x.AiCommentId,
                CommentValue = x.CommentValue,
                DateCreated = x.DateCreated,
                ImageSource = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, x.CommentValue)
            }).ToListAsync();
        }

        // GET: api/AiComment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AiComment>> GetAiComment(int id)
        {
            if (_context.AiComments == null)
            {
                return NotFound();
            }
            var AiComment = await _context.AiComments.FindAsync(id);

            if (AiComment == null)
            {
                return NotFound();
            }

            return AiComment;
        }

        // PUT: api/AiComment/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAiComment(int id, AiComment AiComment)
        {
            if (id != AiComment.AiCommentId)
            {
                return BadRequest();
            }

            _context.Entry(AiComment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AiCommentExists(id))
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

        // POST: api/AiComment
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AiComment>> PostAiComment(AiComment AiComment)
        {
            if (_context.AiComments == null)
            {
                return Problem("Entity set 'KalanchoeAIDatabaseContext.AiComments'  is null.");
            }

            if (AiComment.ImageFile != null)
            {
                AiComment.CommentValue = await SaveImage(AiComment.ImageFile);
            }

            _context.AiComments.Add(AiComment);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAiComment", new { id = AiComment.AiCommentId }, AiComment);
        }

        // DELETE: api/AiComment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAiComment(int id)
        {
            if (_context.AiComments == null)
            {
                return NotFound();
            }
            var AiComment = await _context.AiComments.FindAsync(id);
            if (AiComment == null)
            {
                return NotFound();
            }

            _context.AiComments.Remove(AiComment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AiCommentExists(int id)
        {
            return (_context.AiComments?.Any(e => e.AiCommentId == id)).GetValueOrDefault();
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