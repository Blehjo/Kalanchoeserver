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
    public class CommunityController : ControllerBase
    {
        private readonly KalanchoeAIDatabaseContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public CommunityController(KalanchoeAIDatabaseContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: api/Community
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Community>>> GetCommunities()
        {
            if (_context.Communities == null)
            {
                return NotFound();
            }
            
            return await _context.Communities.Select(x => new Community() {
                CommunityId = x.CommunityId,
                GroupName = x.GroupName,
                Description = x.Description,
                DateCreated = x.DateCreated,
                MediaLink = x.MediaLink,
                ImageSource = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, x.MediaLink)}).ToListAsync();
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

            community.ImageSource = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, community.MediaLink);

            return community;
        }

        [HttpGet("user/{id}")]
        public async Task<ActionResult<IEnumerable<Community>>> GetSingleUserCommunities(int id)
        {
            if (_context.Communities == null)
            {
                return NotFound();
            }

            return await _context.Communities.Where(c => c.UserId == id).Select(x => new Community()
            {
                CommunityId = x.CommunityId,
                GroupName = x.GroupName,
                Description = x.Description,
                DateCreated = x.DateCreated,
                MediaLink = x.MediaLink,
                ImageSource = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, x.MediaLink)
            }).ToListAsync();
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
        public async Task<ActionResult<Community>> PostCommunity([FromForm] Community community)
        {
            if (_context.Communities == null)
            {
                return Problem("Entity set 'KalanchoeAIDatabaseContext.Communities'  is null.");
            }

            community.UserId = Int32.Parse(HttpContext.Request.Cookies["user"]);

            if (community.ImageFile != null)
            {
                community.MediaLink = await SaveImage(community.ImageFile);
            }
            
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
