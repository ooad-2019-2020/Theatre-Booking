using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheatreBooking.Models;

namespace TheaterBooking.Controllers
{
    public class KorisnikUlogaController : Controller
    {
        private readonly BiloStaContext _context;

        public KorisnikUlogaController(BiloStaContext context)
        {
            _context = context;
        }

        // GET: KorisnikUloga
        public async Task<IActionResult> Index()
        {
            return View(await _context.KorisnikUloga.ToListAsync());
        }

        // GET: KorisnikUloga/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var korisnikUloga = await _context.KorisnikUloga
                .FirstOrDefaultAsync(m => m.KorisnikUlogaID == id);
            if (korisnikUloga == null)
            {
                return NotFound();
            }

            return View(korisnikUloga);
        }

        // GET: KorisnikUloga/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KorisnikUloga/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipKorisnika,VrstaKartice,BrojKartice")] KorisnikUloga korisnikUloga)
        {
            if (ModelState.IsValid)
            {
                _context.Add(korisnikUloga);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(korisnikUloga);
        }

        // GET: KorisnikUloga/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var korisnikUloga = await _context.KorisnikUloga.FindAsync(id);
            if (korisnikUloga == null)
            {
                return NotFound();
            }
            return View(korisnikUloga);
        }

        // POST: KorisnikUloga/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipKorisnika,VrstaKartice,BrojKartice")] KorisnikUloga korisnikUloga)
        {
            if (id != korisnikUloga.KorisnikUlogaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(korisnikUloga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KorisnikUlogaExists(korisnikUloga.KorisnikUlogaID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(korisnikUloga);
        }

        // GET: KorisnikUloga/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var korisnikUloga = await _context.KorisnikUloga
                .FirstOrDefaultAsync(m => m.KorisnikUlogaID == id);
            if (korisnikUloga == null)
            {
                return NotFound();
            }

            return View(korisnikUloga);
        }

        // POST: KorisnikUloga/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var korisnikUloga = await _context.KorisnikUloga.FindAsync(id);
            _context.KorisnikUloga.Remove(korisnikUloga);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KorisnikUlogaExists(int id)
        {
            return _context.KorisnikUloga.Any(e => e.KorisnikUlogaID == id);
        }
    }
}
