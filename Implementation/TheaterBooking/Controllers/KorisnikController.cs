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
    public class KorisnikController : Controller
    {
        private readonly BiloStaContext _context;

        public KorisnikController(BiloStaContext context)
        {
            _context = context;
        }

        // GET: Korisnik
        public async Task<IActionResult> Index()
        {
            var biloStaContext = _context.Korisnik.Include(k => k.KorisnikUloga);
            return View(await biloStaContext.ToListAsync());
        }

        // GET: Korisnik/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var korisnik = await _context.Korisnik
                .Include(k => k.KorisnikUloga)
                .FirstOrDefaultAsync(m => m.KorisnikID == id);
            if (korisnik == null)
            {
                return NotFound();
            }

            return View(korisnik);
        }

        // GET: Korisnik/Create
        public IActionResult Create()
        {
            ViewData["KorisnikUlogaID"] = new SelectList(_context.KorisnikUloga, "KorisnikUlogaID", "KorisnikUlogaID");
            return View();
        }

        // POST: Korisnik/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ime,Prezime,Username,Password,Email,KorisnikUlogaID")] Korisnik korisnik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(korisnik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KorisnikUlogaID"] = new SelectList(_context.KorisnikUloga, "KorisnikUlogaID", "KorisnikUlogaID", korisnik.KorisnikUlogaID);
            return View(korisnik);
        }

        // GET: Korisnik/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var korisnik = await _context.Korisnik.FindAsync(id);
            if (korisnik == null)
            {
                return NotFound();
            }
            ViewData["KorisnikUlogaID"] = new SelectList(_context.KorisnikUloga, "KorisnikUlogaID", "KorisnikUlogaID", korisnik.KorisnikUlogaID);
            return View(korisnik);
        }

        // POST: Korisnik/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Ime,Prezime,Username,Password,Email,KorisnikUlogaID")] Korisnik korisnik)
        {
            if (id != korisnik.KorisnikID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(korisnik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KorisnikExists(korisnik.KorisnikID))
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
            ViewData["KorisnikUlogaID"] = new SelectList(_context.KorisnikUloga, "KorisnikUlogaID", "KorisnikUlogaID", korisnik.KorisnikUlogaID);
            return View(korisnik);
        }

        // GET: Korisnik/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var korisnik = await _context.Korisnik
                .Include(k => k.KorisnikUloga)
                .FirstOrDefaultAsync(m => m.KorisnikID == id);
            if (korisnik == null)
            {
                return NotFound();
            }

            return View(korisnik);
        }

        // POST: Korisnik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var korisnik = await _context.Korisnik.FindAsync(id);
            _context.Korisnik.Remove(korisnik);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KorisnikExists(int id)
        {
            return _context.Korisnik.Any(e => e.KorisnikID == id);
        }
    }
}
