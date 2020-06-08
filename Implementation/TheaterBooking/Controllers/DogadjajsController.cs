using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheaterBooking.Models;
using TheatreBooking.Models;

namespace TheaterBooking.Controllers
{
    public class DogadjajsController : Controller
    {
        private readonly BiloStaContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<Korisnik> _userManager; 

        public DogadjajsController(BiloStaContext context, IHttpContextAccessor httpContextAccessor, UserManager<Korisnik> userManager)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        // GET: Dogadjajs
        [Authorize(Roles ="Administrator, Kupac, PremiumKupac")]
        public async Task<IActionResult> Index()
        {
            var user = _httpContextAccessor.HttpContext.User;
            var userFromDb = await _userManager.GetUserAsync(user);
            
            return View(await _context.Dogadjaj.Where(s=>s.CreatedByUserID==userFromDb.Id).ToListAsync());
        }

        // GET: Dogadjajs/Details/5
        [Authorize(Roles = "Administrator, Kupac, PremiumKupac")]
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
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dogadjajs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create([Bind("Naziv,Opis,Slika")] Dogadjaj dogadjaj)
        {
            if (ModelState.IsValid)
            {
                var user = _httpContextAccessor.HttpContext.User;
                var userFromDb = await _userManager.GetUserAsync(user); 
                if (userFromDb != null)
                {
                    dogadjaj.CreatedByUserID = userFromDb.Id; 
                }
                dogadjaj.CreatedDateTime = DateTime.Now;
                _context.Add(dogadjaj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dogadjaj);
        }

        // GET: Dogadjajs/Edit/5
        [Authorize(Roles = "Administrator")]
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
        [Authorize(Roles = "Administrator")]
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
        [Authorize(Roles = "Administrator")]
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
        [Authorize(Roles = "Administrator")]
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
