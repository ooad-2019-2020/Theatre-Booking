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
    public class RezervacijaController : Controller
    {
        private readonly BiloStaContext _context;

        public RezervacijaController(BiloStaContext context)
        {
            _context = context;
        }

        // GET: Rezervacija
        public async Task<IActionResult> Index()
        {
            var biloStaContext = _context.Rezervacija.Include(r => r.Korisnik).Include(r => r.Predstava);
            return View(await biloStaContext.ToListAsync());
        }

        // GET: Rezervacija/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervacija = await _context.Rezervacija
                .Include(r => r.Korisnik)
                .Include(r => r.Predstava)
                .FirstOrDefaultAsync(m => m.RezervacijaID == id);
            if (rezervacija == null)
            {
                return NotFound();
            }

            return View(rezervacija);
        }

        // GET: Rezervacija/Create
        public IActionResult Create()
        {
            ViewData["KorisnikID"] = new SelectList(_context.Korisnik, "KorisnikID", "Email");
            ViewData["PredstavaID"] = new SelectList(_context.Predstava, "PredstavaID", "PredstavaID");
            return View();
        }

        // POST: Rezervacija/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KorisnikID,PredstavaID")] Rezervacija rezervacija)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rezervacija);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KorisnikID"] = new SelectList(_context.Korisnik, "KorisnikID", "Email", rezervacija.KorisnikID);
            ViewData["PredstavaID"] = new SelectList(_context.Predstava, "PredstavaID", "PredstavaID", rezervacija.PredstavaID);
            return View(rezervacija);
        }

        // GET: Rezervacija/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervacija = await _context.Rezervacija.FindAsync(id);
            if (rezervacija == null)
            {
                return NotFound();
            }
            ViewData["KorisnikID"] = new SelectList(_context.Korisnik, "KorisnikID", "Email", rezervacija.KorisnikID);
            ViewData["PredstavaID"] = new SelectList(_context.Predstava, "PredstavaID", "PredstavaID", rezervacija.PredstavaID);
            return View(rezervacija);
        }

        // POST: Rezervacija/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KorisnikID,PredstavaID")] Rezervacija rezervacija)
        {
            if (id != rezervacija.RezervacijaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rezervacija);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RezervacijaExists(rezervacija.RezervacijaID))
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
            ViewData["KorisnikID"] = new SelectList(_context.Korisnik, "KorisnikID", "Email", rezervacija.KorisnikID);
            ViewData["PredstavaID"] = new SelectList(_context.Predstava, "PredstavaID", "PredstavaID", rezervacija.PredstavaID);
            return View(rezervacija);
        }

        // GET: Rezervacija/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervacija = await _context.Rezervacija
                .Include(r => r.Korisnik)
                .Include(r => r.Predstava)
                .FirstOrDefaultAsync(m => m.RezervacijaID == id);
            if (rezervacija == null)
            {
                return NotFound();
            }

            return View(rezervacija);
        }

        // POST: Rezervacija/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rezervacija = await _context.Rezervacija.FindAsync(id);
            _context.Rezervacija.Remove(rezervacija);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RezervacijaExists(int id)
        {
            return _context.Rezervacija.Any(e => e.RezervacijaID == id);
        }
    }
}
