using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentersNz.Areas.Identity.Data;
using RentersNz.Models;
using System.Linq;
using System.Threading.Tasks;

namespace RentersNz.Controllers
{
    public class LandlordsController : Controller
    {
        private readonly RentersNzDbContext _context;

        public LandlordsController(RentersNzDbContext context)
        {
            _context = context;
        }

        // GET: Landlords
        public async Task<IActionResult> Index(string searchString)
        {
            var landlords = from l in _context.Landlord
                            select l;

            if (!string.IsNullOrEmpty(searchString))
            {
                landlords = landlords.Where(s => s.Name.Contains(searchString) || s.Email.Contains(searchString));
            }

            ViewData["CurrentFilter"] = searchString;

            return View(await landlords.ToListAsync());
        }

        // GET: Landlords/Details/5
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

        // GET: Landlords/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Landlords/Create
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

        // GET: Landlords/Edit/5
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

        // POST: Landlords/Edit/5
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

        // GET: Landlords/Delete/5
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

        // POST: Landlords/Delete/5
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
