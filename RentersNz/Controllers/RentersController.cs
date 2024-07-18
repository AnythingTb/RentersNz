using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentersNz.Areas.Identity.Data;
using RentersNz.Models;
using System.Linq;
using System.Threading.Tasks;

namespace RentersNz.Controllers
{
    public class RentersController : Controller
    {
        private readonly RentersNzDbContext _context;

        public RentersController(RentersNzDbContext context)
        {
            _context = context;
        }

        // GET: Renters
        [Authorize]
        public async Task<IActionResult> Index(string searchString)
        {
            var renters = from r in _context.Renter
                          select r;

            if (!string.IsNullOrEmpty(searchString))
            {
                renters = renters.Where(s => s.RenterName.Contains(searchString));
            }

            ViewData["CurrentFilter"] = searchString;

            return View(await renters.ToListAsync());
        }

        // GET: Renters/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var renter = await _context.Renter
                .FirstOrDefaultAsync(m => m.RenterId == id);
            if (renter == null)
            {
                return NotFound();
            }

            return View(renter);
        }

        // GET: Renters/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Renters/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RenterId,RenterName,RenterDescription,Bedrooms,Bathrooms,AnimalSupport,SquareFootprint,UnitorStandAlone")] Renter renter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(renter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(renter);
        }

        // GET: Renters/Edit/5
        [Authorize(Roles = "Administrators")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var renter = await _context.Renter.FindAsync(id);
            if (renter == null)
            {
                return NotFound();
            }
            return View(renter);
        }

        // POST: Renters/Edit/5
        [Authorize(Roles = "Administrators")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RenterId,RenterName,RenterDescription,Bedrooms,Bathrooms,AnimalSupport,SquareFootprint,UnitorStandAlone")] Renter renter)
        {
            if (id != renter.RenterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(renter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RenterExists(renter.RenterId))
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
            return View(renter);
        }

        // GET: Renters/Delete/5
        [Authorize(Roles = "Administrators")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var renter = await _context.Renter
                .FirstOrDefaultAsync(m => m.RenterId == id);
            if (renter == null)
            {
                return NotFound();
            }

            return View(renter);
        }

        // POST: Renters/Delete/5
        [Authorize(Roles = "Administrators")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var renter = await _context.Renter.FindAsync(id);
            if (renter != null)
            {
                _context.Renter.Remove(renter);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RenterExists(int id)
        {
            return _context.Renter.Any(e => e.RenterId == id);
        }
    }
}
