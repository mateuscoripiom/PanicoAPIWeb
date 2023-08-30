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
    public class TbUsersController : ControllerBase
    {
        private readonly DbPanicoContext _context;

        public TbUsersController(DbPanicoContext context)
        {
            _context = context;
        }

        // GET: api/TbUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbUser>>> GetTbUsers()
        {
          if (_context.TbUsers == null)
          {
              return NotFound();
          }
            return await _context.TbUsers.ToListAsync();
        }

        // GET: api/TbUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbUser>> GetTbUser(int id)
        {
          if (_context.TbUsers == null)
          {
              return NotFound();
          }
            var tbUser = await _context.TbUsers.FindAsync(id);

            if (tbUser == null)
            {
                return NotFound();
            }

            return tbUser;
        }

        // PUT: api/TbUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbUser(int id, TbUser tbUser)
        {
            if (id != tbUser.IdUser)
            {
                return BadRequest();
            }

            _context.Entry(tbUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbUserExists(id))
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

        // POST: api/TbUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbUser>> PostTbUser(TbUser tbUser)
        {
          if (_context.TbUsers == null)
          {
              return Problem("Entity set 'DbPanicoContext.TbUsers'  is null.");
          }
            _context.TbUsers.Add(tbUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbUser", new { id = tbUser.IdUser }, tbUser);
        }

        // DELETE: api/TbUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbUser(int id)
        {
            if (_context.TbUsers == null)
            {
                return NotFound();
            }
            var tbUser = await _context.TbUsers.FindAsync(id);
            if (tbUser == null)
            {
                return NotFound();
            }

            _context.TbUsers.Remove(tbUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbUserExists(int id)
        {
            return (_context.TbUsers?.Any(e => e.IdUser == id)).GetValueOrDefault();
        }
    }
}
