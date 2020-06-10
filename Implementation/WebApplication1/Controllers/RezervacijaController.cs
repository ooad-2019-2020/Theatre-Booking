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
    public class RezervacijaController : ControllerBase
    {
        private readonly BiloSTaContext _context;

        public RezervacijaController(BiloSTaContext context)
        {
            _context = context;
        }

        // GET: api/Rezervacija
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rezervacija>>> GetRezervacija()
        {
            return await _context.Rezervacija.ToListAsync();
        }

        // GET: api/Rezervacija/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rezervacija>> GetRezervacija(int id)
        {
            var rezervacija = await _context.Rezervacija.FindAsync(id);

            if (rezervacija == null)
            {
                return NotFound();
            }

            return rezervacija;
        }

        // PUT: api/Rezervacija/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRezervacija(int id, Rezervacija rezervacija)
        {
            if (id != rezervacija.RezervacijaId)
            {
                return BadRequest();
            }

            _context.Entry(rezervacija).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RezervacijaExists(id))
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

        // POST: api/Rezervacija
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Rezervacija>> PostRezervacija(Rezervacija rezervacija)
        {
            _context.Rezervacija.Add(rezervacija);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRezervacija", new { id = rezervacija.RezervacijaId }, rezervacija);
        }

        // DELETE: api/Rezervacija/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Rezervacija>> DeleteRezervacija(int id)
        {
            var rezervacija = await _context.Rezervacija.FindAsync(id);
            if (rezervacija == null)
            {
                return NotFound();
            }

            _context.Rezervacija.Remove(rezervacija);
            await _context.SaveChangesAsync();

            return rezervacija;
        }

        private bool RezervacijaExists(int id)
        {
            return _context.Rezervacija.Any(e => e.RezervacijaId == id);
        }
    }
}
