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
    public class PanelController : ControllerBase
    {
        private readonly KalanchoeAIDatabaseContext _context;

        public PanelController(KalanchoeAIDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Panel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Panel>>> GetPanels()
        {
          if (_context.Panels == null)
          {
              return NotFound();
          }
            return await _context.Panels.ToListAsync();
        }

        // GET: api/Panel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Panel>> GetPanel(int id)
        {
          if (_context.Panels == null)
          {
              return NotFound();
          }
            var panel = await _context.Panels.FindAsync(id);

            if (panel == null)
            {
                return NotFound();
            }

            return panel;
        }

        // PUT: api/Panel/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPanel(int id, Panel panel)
        {
            if (id != panel.PanelId)
            {
                return BadRequest();
            }

            _context.Entry(panel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PanelExists(id))
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

        // POST: api/Panel
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Panel>> PostPanel(Panel panel)
        {
          if (_context.Panels == null)
          {
              return Problem("Entity set 'KalanchoeAIDatabaseContext.Panels'  is null.");
          }
            _context.Panels.Add(panel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPanel", new { id = panel.PanelId }, panel);
        }

        // DELETE: api/Panel/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePanel(int id)
        {
            if (_context.Panels == null)
            {
                return NotFound();
            }
            var panel = await _context.Panels.FindAsync(id);
            if (panel == null)
            {
                return NotFound();
            }

            _context.Panels.Remove(panel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PanelExists(int id)
        {
            return (_context.Panels?.Any(e => e.PanelId == id)).GetValueOrDefault();
        }
    }
}
