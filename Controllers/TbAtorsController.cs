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
    public class TbAtorsController : ControllerBase
    {
        private readonly DbPanicoContext _context;

        public TbAtorsController(DbPanicoContext context)
        {
            _context = context;
        }

        // GET: api/TbAtors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbAtor>>> GetTbAtors()
        {
          if (_context.TbAtors == null)
          {
              return NotFound();
          }
            return await _context.TbAtors.ToListAsync();
        }

        // GET: api/TbAtors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbAtor>> GetTbAtor(int id)
        {
          if (_context.TbAtors == null)
          {
              return NotFound();
          }
            var tbAtor = await _context.TbAtors.FindAsync(id);

            if (tbAtor == null)
            {
                return NotFound();
            }

            return tbAtor;
        }

        // PUT: api/TbAtors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbAtor(int id, TbAtor tbAtor)
        {
            if (id != tbAtor.IdAtor)
            {
                return BadRequest();
            }

            _context.Entry(tbAtor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbAtorExists(id))
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

        // POST: api/TbAtors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbAtor>> PostTbAtor(TbAtor tbAtor)
        {
          if (_context.TbAtors == null)
          {
              return Problem("Entity set 'DbPanicoContext.TbAtors'  is null.");
          }
            _context.TbAtors.Add(tbAtor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbAtor", new { id = tbAtor.IdAtor }, tbAtor);
        }

        // DELETE: api/TbAtors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbAtor(int id)
        {
            if (_context.TbAtors == null)
            {
                return NotFound();
            }
            var tbAtor = await _context.TbAtors.FindAsync(id);
            if (tbAtor == null)
            {
                return NotFound();
            }

            _context.TbAtors.Remove(tbAtor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbAtorExists(int id)
        {
            return (_context.TbAtors?.Any(e => e.IdAtor == id)).GetValueOrDefault();
        }
    }
}
