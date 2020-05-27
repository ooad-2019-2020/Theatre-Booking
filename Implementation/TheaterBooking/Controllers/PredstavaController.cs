using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheatreBooking.Models;

namespace TheaterBooking.Controllers
{
    public class PredstavaController : Controller
    {
        private readonly BiloStaContext _context;

        public PredstavaController(BiloStaContext context)
        {
            _context = context;
        }

        // GET: Predstava
        public async Task<IActionResult> Index()
        {
            var biloStaContext = _context.Predstava.Include(p => p.Dogadjaj);
            return View(await biloStaContext.ToListAsync());
        }

        // GET: Predstava/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var predstava = await _context.Predstava
                .Include(p => p.Dogadjaj)
                .FirstOrDefaultAsync(m => m.PredstavaID == id);
            if (predstava == null)
            {
                return NotFound();
            }

            return View(predstava);
        }

        // GET: Predstava/Create
        public IActionResult Create()
        {
            ViewData["DogadjajID"] = new SelectList(_context.Dogadjaj, "DogadjajID", "Naziv");
            return View();
        }

        // POST: Predstava/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Termin,DogadjajID")] Predstava predstava)
        {
            if (ModelState.IsValid)
            {
                _context.Add(predstava);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DogadjajID"] = new SelectList(_context.Dogadjaj, "DogadjajID", "Naziv", predstava.DogadjajID);
            return View(predstava);
        }

        // GET: Predstava/Edit/5
        [Authorize (Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var predstava = await _context.Predstava.FindAsync(id);
            if (predstava == null)
            {
                return NotFound();
            }
            ViewData["DogadjajID"] = new SelectList(_context.Dogadjaj, "DogadjajID", "Naziv", predstava.DogadjajID);
            return View(predstava);
        }

        // POST: Predstava/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Termin,DogadjajID")] Predstava predstava)
        {
            if (id != predstava.PredstavaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(predstava);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PredstavaExists(predstava.PredstavaID))
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
            ViewData["DogadjajID"] = new SelectList(_context.Dogadjaj, "DogadjajID", "Naziv", predstava.DogadjajID);
            return View(predstava);
        }

        // GET: Predstava/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var predstava = await _context.Predstava
                .Include(p => p.Dogadjaj)
                .FirstOrDefaultAsync(m => m.PredstavaID == id);
            if (predstava == null)
            {
                return NotFound();
            }

            return View(predstava);
        }

        // POST: Predstava/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var predstava = await _context.Predstava.FindAsync(id);
            _context.Predstava.Remove(predstava);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PredstavaExists(int id)
        {
            return _context.Predstava.Any(e => e.PredstavaID == id);
        }
    }
}
