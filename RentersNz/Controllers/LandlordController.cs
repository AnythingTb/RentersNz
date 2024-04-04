using Microsoft.AspNetCore.Mvc;
using RentersNz.Areas.Identity.Data;
using RentersNz.Models;
using RentersNz.Models.Entities;

namespace RentersNz.Controllers
{
    public class LandlordController : Controller
    {
        private readonly RentersNzDbContext dbContext;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public LandlordController(RentersNzDbContext dbContext)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddLandlordViewModel viewModel)
        {
            var landlord = new Landlord
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                PhoneNumber = viewModel.PhoneNumber,
                Address = viewModel.Address,
                City = viewModel.City,
                Region = viewModel.Region,
                PostalCode = viewModel.PostalCode,
                Description = viewModel.Description

            };

            await dbContext.Landlord.AddAsync(Landlord);
            await dbContext.SaveChangesAsync();


            return View();
        }
    }
}
