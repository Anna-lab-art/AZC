using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AZC.Context;
using AZC.Model;

namespace AZC.Controllers
{
    public class PetronsController : Controller
    {
        private readonly AppDbContext _context;

        public PetronsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Petrons
        public async Task<IActionResult> Index()
        {
            return View(await _context.Petron.ToListAsync());
        }

        // GET: Petrons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petron = await _context.Petron
                .FirstOrDefaultAsync(m => m.id == id);
            if (petron == null)
            {
                return NotFound();
            }

            return View(petron);
        }

        // GET: Petrons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Petrons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Name,Price,AmountOfFuel,Station_ID")] Petron petron)
        {
            if (ModelState.IsValid)
            {
                _context.Add(petron);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(petron);
        }

        // GET: Petrons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petron = await _context.Petron.FindAsync(id);
            if (petron == null)
            {
                return NotFound();
            }
            return View(petron);
        }

        // POST: Petrons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Name,Price,AmountOfFuel,Station_ID")] Petron petron)
        {
            if (id != petron.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(petron);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetronExists(petron.id))
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
            return View(petron);
        }

        // GET: Petrons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petron = await _context.Petron
                .FirstOrDefaultAsync(m => m.id == id);
            if (petron == null)
            {
                return NotFound();
            }

            return View(petron);
        }

        // POST: Petrons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var petron = await _context.Petron.FindAsync(id);
            _context.Petron.Remove(petron);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PetronExists(int id)
        {
            return _context.Petron.Any(e => e.id == id);
        }
    }
}
