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
    public class TbObrasController : ControllerBase
    {
        private readonly DbPanicoContext _context;

        public TbObrasController(DbPanicoContext context)
        {
            _context = context;
        }

        // GET: api/TbObras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbObra>>> GetTbObras()
        {
          if (_context.TbObras == null)
          {
              return NotFound();
          }
            return await _context.TbObras.ToListAsync();
        }

        // GET: api/TbObras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbObra>> GetTbObra(int id)
        {
          if (_context.TbObras == null)
          {
              return NotFound();
          }
            var tbObra = await _context.TbObras.FindAsync(id);

            if (tbObra == null)
            {
                return NotFound();
            }

            return tbObra;
        }

        // PUT: api/TbObras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbObra(int id, TbObra tbObra)
        {
            if (id != tbObra.IdObra)
            {
                return BadRequest();
            }

            _context.Entry(tbObra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbObraExists(id))
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

        // POST: api/TbObras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbObra>> PostTbObra(TbObra tbObra)
        {
          if (_context.TbObras == null)
          {
              return Problem("Entity set 'DbPanicoContext.TbObras'  is null.");
          }
            _context.TbObras.Add(tbObra);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbObra", new { id = tbObra.IdObra }, tbObra);
        }

        // DELETE: api/TbObras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbObra(int id)
        {
            if (_context.TbObras == null)
            {
                return NotFound();
            }
            var tbObra = await _context.TbObras.FindAsync(id);
            if (tbObra == null)
            {
                return NotFound();
            }

            _context.TbObras.Remove(tbObra);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbObraExists(int id)
        {
            return (_context.TbObras?.Any(e => e.IdObra == id)).GetValueOrDefault();
        }
    }
}
