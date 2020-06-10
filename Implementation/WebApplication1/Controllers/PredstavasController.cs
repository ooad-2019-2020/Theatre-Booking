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
    public class PredstavasController : ControllerBase
    {
        private readonly BiloSTaContext _context;

        public PredstavasController(BiloSTaContext context)
        {
            _context = context;
        }

        // GET: api/Predstavas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Predstava>>> GetPredstava()
        {
            return await _context.Predstava.ToListAsync();
        }

        // GET: api/Predstavas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Predstava>> GetPredstava(int id)
        {
            var predstava = await _context.Predstava.FindAsync(id);

            if (predstava == null)
            {
                return NotFound();
            }

            return predstava;
        }

        // PUT: api/Predstavas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPredstava(int id, Predstava predstava)
        {
            if (id != predstava.PredstavaId)
            {
                return BadRequest();
            }

            _context.Entry(predstava).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PredstavaExists(id))
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

        // POST: api/Predstavas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Predstava>> PostPredstava(Predstava predstava)
        {
            _context.Predstava.Add(predstava);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPredstava", new { id = predstava.PredstavaId }, predstava);
        }

        // DELETE: api/Predstavas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Predstava>> DeletePredstava(int id)
        {
            var predstava = await _context.Predstava.FindAsync(id);
            if (predstava == null)
            {
                return NotFound();
            }

            _context.Predstava.Remove(predstava);
            await _context.SaveChangesAsync();

            return predstava;
        }

        private bool PredstavaExists(int id)
        {
            return _context.Predstava.Any(e => e.PredstavaId == id);
        }
    }
}
