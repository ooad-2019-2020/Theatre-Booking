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
    public class DogadjajController : ControllerBase
    {
        private readonly BiloSTaContext _context;

        public DogadjajController(BiloSTaContext context)
        {
            _context = context;
        }

        // GET: api/Dogadjaj
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dogadjaj>>> GetDogadjaj()
        {
            return await _context.Dogadjaj.ToListAsync();
        }

        // GET: api/Dogadjaj/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dogadjaj>> GetDogadjaj(int id)
        {
            var dogadjaj = await _context.Dogadjaj.FindAsync(id);

            if (dogadjaj == null)
            {
                return NotFound();
            }

            return dogadjaj;
        }

        // PUT: api/Dogadjaj/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDogadjaj(int id, Dogadjaj dogadjaj)
        {
            if (id != dogadjaj.DogadjajId)
            {
                return BadRequest();
            }

            _context.Entry(dogadjaj).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DogadjajExists(id))
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

        // POST: api/Dogadjaj
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Dogadjaj>> PostDogadjaj(Dogadjaj dogadjaj)
        {
            _context.Dogadjaj.Add(dogadjaj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDogadjaj", new { id = dogadjaj.DogadjajId }, dogadjaj);
        }

        // DELETE: api/Dogadjaj/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dogadjaj>> DeleteDogadjaj(int id)
        {
            var dogadjaj = await _context.Dogadjaj.FindAsync(id);
            if (dogadjaj == null)
            {
                return NotFound();
            }

            _context.Dogadjaj.Remove(dogadjaj);
            await _context.SaveChangesAsync();

            return dogadjaj;
        }

        private bool DogadjajExists(int id)
        {
            return _context.Dogadjaj.Any(e => e.DogadjajId == id);
        }
    }
}
