using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using KalanchoeAI_Backend.Data;
using KalanchoeAI_Backend.Models;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Hosting;

namespace KalanchoeAI_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChannelCommentController : ControllerBase
    {
        private readonly KalanchoeAIDatabaseContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ChannelCommentController(KalanchoeAIDatabaseContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: api/ChannelComment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChannelComment>>> GetChannelComments()
        {
            if (_context.ChannelComments == null)
            {
                return NotFound();
            }

            return await _context.ChannelComments.Select(x => new ChannelComment() {
                ChannelCommentId = x.ChannelCommentId,
                ChannelCommentValue = x.ChannelCommentValue,
                UserId = x.UserId,
                DateCreated = x.DateCreated,
                MediaLink = x.MediaLink,
                ImageSource = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, x.MediaLink)}).ToListAsync();
        }

        // GET: api/ChannelComment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ChannelComment>>> GetChannelComment(int id)
        {
            if (_context.ChannelComments == null)
            {
                return NotFound();
            }

            return await _context.ChannelComments.Where(c => c.ChannelId == id).Select(x => new ChannelComment()
            {
                ChannelCommentId = x.ChannelCommentId,
                ChannelCommentValue = x.ChannelCommentValue,
                UserId = x.UserId,
                DateCreated = x.DateCreated,
                MediaLink = x.MediaLink,
                ImageSource = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, x.MediaLink)
            }).ToListAsync();
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
        public async Task<ActionResult<ChannelComment>> PostChannelComment([FromForm] ChannelComment channelComment)
        {
            if (_context.ChannelComments == null)
            {
                return Problem("Entity set 'KalanchoeAIDatabaseContext.ChannelComments'  is null.");
            }

            channelComment.UserId = Int32.Parse(HttpContext.Request.Cookies["user"]);

            if (channelComment.ImageFile != null)
            {
                channelComment.MediaLink = await SaveImage(channelComment.ImageFile);
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
