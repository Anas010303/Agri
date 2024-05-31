using Microsoft.AspNetCore.Mvc;
using Agri.Models;
using System.Threading.Tasks;

namespace Agri.Controllers
{
    public class FarmerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FarmerController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            var farmer = _context.Farmers.FirstOrDefault(f => f.FarmerName == "John Doe"); // Replace with logged-in farmer
            if (farmer == null)
            {
                // Handle the case when the farmer is not found, e.g., return an error view or a default view model
                return View("FarmerNotFound"); // Create a view called "FarmerNotFound" to handle this case
            }

            var viewModel = new Farmer
            {
                FarmerName = farmer.FarmerName,
                Products = farmer.Products?.ToList() ?? new List<Product>() // Handle potential null Products
            };
            return View(viewModel);
        }


        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                var farmer = _context.Farmers.FirstOrDefault(f => f.FarmerName == "John Doe"); // Replace with logged-in farmer
                product.FarmerId = farmer.FarmerId;
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction("Dashboard");
            }
            return View(product);
        }
    }
}