using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SjedistesController : ControllerBase
    {
        private readonly BiloSTaContext _context;

        public SjedistesController(BiloSTaContext context)
        {
            _context = context;
        }

        // GET: api/Sjedistes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sjediste>>> GetSjediste()
        {
            return await _context.Sjediste.ToListAsync();
        }

        // GET: api/Sjedistes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sjediste>> GetSjediste(int id)
        {
            var sjediste = await _context.Sjediste.FindAsync(id);

            if (sjediste == null)
            {
                return NotFound();
            }

            return sjediste;
        }

        // PUT: api/Sjedistes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSjediste(int id, Sjediste sjediste)
        {
            if (id != sjediste.SjedisteId)
            {
                return BadRequest();
            }

            _context.Entry(sjediste).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SjedisteExists(id))
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

        // POST: api/Sjedistes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Sjediste>> PostSjediste(Sjediste sjediste)
        {
            _context.Sjediste.Add(sjediste);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSjediste", new { id = sjediste.SjedisteId }, sjediste);
        }

        // DELETE: api/Sjedistes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sjediste>> DeleteSjediste(int id)
        {
            var sjediste = await _context.Sjediste.FindAsync(id);
            if (sjediste == null)
            {
                return NotFound();
            }

            _context.Sjediste.Remove(sjediste);
            await _context.SaveChangesAsync();

            return sjediste;
        }

        private bool SjedisteExists(int id)
        {
            return _context.Sjediste.Any(e => e.SjedisteId == id);
        }
    }
}
