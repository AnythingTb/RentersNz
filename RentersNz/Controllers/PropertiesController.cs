using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentersNz.Areas.Identity.Data;
using RentersNz.Models;
using System.Linq;
using System.Threading.Tasks;

namespace RentersNz.Controllers
{
    [Authorize]
    public class PropertiesController : Controller
    {
        private readonly RentersNzDbContext _context;

        public PropertiesController(RentersNzDbContext context)
        {
            _context = context;
        }

        // GET: Properties
        public async Task<IActionResult> Index(string searchString)
        {
            var properties = _context.Property.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();

                properties = properties.Where(p =>
                    p.Address.Contains(searchString) ||
                    p.City.Contains(searchString) ||
                    p.Description.Contains(searchString));
            }

            ViewData["CurrentFilter"] = searchString;

            return View(await properties.ToListAsync());
        }

        // GET: Properties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var property = await _context.Property
                .FirstOrDefaultAsync(m => m.PropertyId == id);

            if (property == null)
            {
                return NotFound();
            }

            return View(property);
        }

        // GET: Properties/Create
        [Authorize(Roles = "Administrators")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Properties/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrators")]
        public async Task<IActionResult> Create([Bind("PropertyId,LandlordId,Address,City,Region,PostalCode,PropertyType,Bedrooms,Bathrooms,Rent,AvailableDate,Description,ImageURLs")] Property property)
        {
            if (ModelState.IsValid)
            {
                _context.Add(property);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(property);
        }

        // GET: Properties/Edit/5
        [Authorize(Roles = "Administrators")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var property = await _context.Property.FindAsync(id);

            if (property == null)
            {
                return NotFound();
            }

            return View(property);
        }

        // POST: Properties/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrators")]
        public async Task<IActionResult> Edit(int id, [Bind("PropertyId,LandlordId,Address,City,Region,PostalCode,PropertyType,Bedrooms,Bathrooms,Rent,AvailableDate,Description,ImageURLs")] Property property)
        {
            if (id != property.PropertyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(property);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertyExists(property.PropertyId))
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
            return View(property);
        }

        // GET: Properties/Delete/5
        [Authorize(Roles = "Administrators")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var property = await _context.Property
                .FirstOrDefaultAsync(m => m.PropertyId == id);

            if (property == null)
            {
                return NotFound();
            }

            return View(property);
        }

        // POST: Properties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrators")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var property = await _context.Property.FindAsync(id);

            if (property != null)
            {
                _context.Property.Remove(property);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool PropertyExists(int id)
        {
            return _context.Property.Any(e => e.PropertyId == id);
        }
    }
}
