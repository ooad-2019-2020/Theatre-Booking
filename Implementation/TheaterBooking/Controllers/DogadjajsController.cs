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
    public class DogadjajsController : Controller
    {
        private readonly BiloStaContext _context;

        public DogadjajsController(BiloStaContext context)
        {
            _context = context;
        }

        // GET: Dogadjajs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dogadjaj.ToListAsync());
        }

        // GET: Dogadjajs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dogadjaj = await _context.Dogadjaj
                .FirstOrDefaultAsync(m => m.DogadjajID == id);
            if (dogadjaj == null)
            {
                return NotFound();
            }

            return View(dogadjaj);
        }

        // GET: Dogadjajs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dogadjajs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Naziv,Opis,Slika")] Dogadjaj dogadjaj)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dogadjaj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dogadjaj);
        }

        // GET: Dogadjajs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dogadjaj = await _context.Dogadjaj.FindAsync(id);
            if (dogadjaj == null)
            {
                return NotFound();
            }
            return View(dogadjaj);
        }

        // POST: Dogadjajs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Naziv,Opis,Slika")] Dogadjaj dogadjaj)
        {
            if (id != dogadjaj.DogadjajID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dogadjaj);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DogadjajExists(dogadjaj.DogadjajID))
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
            return View(dogadjaj);
        }

        // GET: Dogadjajs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dogadjaj = await _context.Dogadjaj
                .FirstOrDefaultAsync(m => m.DogadjajID == id);
            if (dogadjaj == null)
            {
                return NotFound();
            }

            return View(dogadjaj);
        }

        // POST: Dogadjajs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dogadjaj = await _context.Dogadjaj.FindAsync(id);
            _context.Dogadjaj.Remove(dogadjaj);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DogadjajExists(int id)
        {
            return _context.Dogadjaj.Any(e => e.DogadjajID == id);
        }
    }
}
