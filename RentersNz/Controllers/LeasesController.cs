﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentersNz.Areas.Identity.Data;
using RentersNz.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace RentersNz.Controllers
{
    public class LeasesController : Controller
    {
        private readonly RentersNzDbContext _context;

        public LeasesController(RentersNzDbContext context)
        {
            _context = context;
        }

        // GET: Leases
        [Authorize]
        public async Task<IActionResult> Index(string searchString)
        {
            var leases = from l in _context.Lease
                         select l;

            if (!string.IsNullOrEmpty(searchString))
            {
                leases = leases.Where(s => s.PropertyId.ToString().Contains(searchString) || s.RenterId.ToString().Contains(searchString));
            }

            ViewData["CurrentFilter"] = searchString;

            return View(await leases.ToListAsync());
        }

        // GET: Leases/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lease = await _context.Lease
                .FirstOrDefaultAsync(m => m.LeaseId == id);
            if (lease == null)
            {
                return NotFound();
            }

            return View(lease);
        }

        // GET: Leases/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Leases/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LeaseId,PropertyId,RenterId,StartDate,EndDate,DepositAmount,MonthlyRent,AdditionalTerms")] Lease lease)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lease);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lease);
        }

        // GET: Leases/Edit/5
        [Authorize(Roles = "Administrators")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lease = await _context.Lease.FindAsync(id);
            if (lease == null)
            {
                return NotFound();
            }
            return View(lease);
        }

        // POST: Leases/Edit/5
        [Authorize(Roles = "Administrators")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LeaseId,PropertyId,RenterId,StartDate,EndDate,DepositAmount,MonthlyRent,AdditionalTerms")] Lease lease)
        {
            if (id != lease.LeaseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lease);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaseExists(lease.LeaseId))
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
            return View(lease);
        }

        // GET: Leases/Delete/5
        [Authorize(Roles = "Administrators")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lease = await _context.Lease
                .FirstOrDefaultAsync(m => m.LeaseId == id);
            if (lease == null)
            {
                return NotFound();
            }

            return View(lease);
        }

        // POST: Leases/Delete/5
        [Authorize(Roles = "Administrators")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lease = await _context.Lease.FindAsync(id);
            if (lease != null)
            {
                _context.Lease.Remove(lease);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaseExists(int id)
        {
            return _context.Lease.Any(e => e.LeaseId == id);
        }
    }
}
