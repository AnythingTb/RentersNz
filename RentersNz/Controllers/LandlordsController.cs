using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentersNz.Areas.Identity.Data;
using RentersNz.Models;

namespace RentersNz.Controllers
{
    public class LandlordsController : Controller
    {
        private readonly RentersNzDbContext _context;

        public LandlordsController(RentersNzDbContext context)
        {
            _context = context;
        }

     
        public async Task<IActionResult> Index()
        {
            return View(await _context.Landlord.ToListAsync());
        }

        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var landlord = await _context.Landlord
                .FirstOrDefaultAsync(m => m.LandlordId == id);
            if (landlord == null)
            {
                return NotFound();
            }

            return View(landlord);
        }

    
        public IActionResult Create()
        {
            return View();
        }

    
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LandlordId,Name,Email,PhoneNumber,Address,City,Region,PostalCode,Description")] Landlord landlord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(landlord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(landlord);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var landlord = await _context.Landlord.FindAsync(id);
            if (landlord == null)
            {
                return NotFound();
            }
            return View(landlord);
        }

      
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LandlordId,Name,Email,PhoneNumber,Address,City,Region,PostalCode,Description")] Landlord landlord)
        {
            if (id != landlord.LandlordId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(landlord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LandlordExists(landlord.LandlordId))
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
            return View(landlord);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var landlord = await _context.Landlord
                .FirstOrDefaultAsync(m => m.LandlordId == id);
            if (landlord == null)
            {
                return NotFound();
            }

            return View(landlord);
        }

    
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var landlord = await _context.Landlord.FindAsync(id);
            if (landlord != null)
            {
                _context.Landlord.Remove(landlord);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LandlordExists(int id)
        {
            return _context.Landlord.Any(e => e.LandlordId == id);
        }
    }
}
