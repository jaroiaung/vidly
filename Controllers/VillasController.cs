using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using vidly.Data;
using vidly.Models;
using vidly.Utility;

namespace vidly.Controllers
{
    [Authorize(Roles = SD.Role_Admin)]
    
    public class VillasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VillasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Villas
        public async Task<IActionResult> Index()
        {
              return _context.Villas != null ? 
                          View(await _context.Villas.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Villas'  is null.");
        }

        // GET: Villas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Villas == null)
            {
                return NotFound();
            }

            var villa = await _context.Villas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (villa == null)
            {
                return NotFound();
            }

            return View(villa);
        }

        // GET: Villas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Villas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Details,Rate,Sqft,Occupancy,ImageUrl,Amenity,CreatedDate,UpdatedDate")] Villa villa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(villa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(villa);
        }

        // GET: Villas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Villas == null)
            {
                return NotFound();
            }

            var villa = await _context.Villas.FindAsync(id);
            if (villa == null)
            {
                return NotFound();
            }
            return View(villa);
        }

        // POST: Villas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Details,Rate,Sqft,Occupancy,ImageUrl,Amenity,CreatedDate,UpdatedDate")] Villa villa)
        {
            if (id != villa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(villa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VillaExists(villa.Id))
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
            return View(villa);
        }

        // GET: Villas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Villas == null)
            {
                return NotFound();
            }

            var villa = await _context.Villas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (villa == null)
            {
                return NotFound();
            }

            return View(villa);
        }

        // POST: Villas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Villas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Villas'  is null.");
            }
            var villa = await _context.Villas.FindAsync(id);
            if (villa != null)
            {
                _context.Villas.Remove(villa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VillaExists(int id)
        {
          return (_context.Villas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
