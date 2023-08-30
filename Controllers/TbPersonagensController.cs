using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PanicoAPIWeb.DataContext;
using PanicoAPIWeb.Models;

namespace PanicoAPIWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TbPersonagensController : ControllerBase
    {
        private readonly DbPanicoContext _context;

        public TbPersonagensController(DbPanicoContext context)
        {
            _context = context;
        }

        // GET: api/TbPersonagens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbPersonagen>>> GetTbPersonagens()
        {
          if (_context.TbPersonagens == null)
          {
              return NotFound();
          }
            return await _context.TbPersonagens.ToListAsync();
        }

        // GET: api/TbPersonagens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbPersonagen>> GetTbPersonagen(int id)
        {
          if (_context.TbPersonagens == null)
          {
              return NotFound();
          }
            var tbPersonagen = await _context.TbPersonagens.FindAsync(id);

            if (tbPersonagen == null)
            {
                return NotFound();
            }

            return tbPersonagen;
        }

        // PUT: api/TbPersonagens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbPersonagen(int id, TbPersonagen tbPersonagen)
        {
            if (id != tbPersonagen.IdPerson)
            {
                return BadRequest();
            }

            _context.Entry(tbPersonagen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbPersonagenExists(id))
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

        // POST: api/TbPersonagens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbPersonagen>> PostTbPersonagen(TbPersonagen tbPersonagen)
        {
          if (_context.TbPersonagens == null)
          {
              return Problem("Entity set 'DbPanicoContext.TbPersonagens'  is null.");
          }
            _context.TbPersonagens.Add(tbPersonagen);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbPersonagen", new { id = tbPersonagen.IdPerson }, tbPersonagen);
        }

        // DELETE: api/TbPersonagens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbPersonagen(int id)
        {
            if (_context.TbPersonagens == null)
            {
                return NotFound();
            }
            var tbPersonagen = await _context.TbPersonagens.FindAsync(id);
            if (tbPersonagen == null)
            {
                return NotFound();
            }

            _context.TbPersonagens.Remove(tbPersonagen);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbPersonagenExists(int id)
        {
            return (_context.TbPersonagens?.Any(e => e.IdPerson == id)).GetValueOrDefault();
        }
    }
}
