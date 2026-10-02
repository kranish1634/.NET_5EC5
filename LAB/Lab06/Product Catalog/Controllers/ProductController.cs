using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Models;

namespace ProductCatalog.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Laptop",
                Category = "Electronics",
                Brand = "Dell",
                Price = 55000,
                Stock = 10,
                Description = "Dell laptop with Intel Core i5 processor, 8GB RAM and 512GB SSD."
            },

            new Product
            {
                Id = 2,
                Name = "Smartphone",
                Category = "Electronics",
                Brand = "Samsung",
                Price = 25000,
                Stock = 15,
                Description = "Samsung smartphone with AMOLED display and 128GB storage."
            },

            new Product
            {
                Id = 3,
                Name = "Headphones",
                Category = "Accessories",
                Brand = "Sony",
                Price = 2000,
                Stock = 20,
                Description = "Sony wireless headphones with noise cancellation."
            },

            new Product
            {
                Id = 4,
                Name = "Keyboard",
                Category = "Accessories",
                Brand = "Logitech",
                Price = 1500,
                Stock = 25,
                Description = "Wireless keyboard suitable for office and gaming use."
            },

            new Product
            {
                Id = 5,
                Name = "Smart Watch",
                Category = "Wearables",
                Brand = "Noise",
                Price = 3500,
                Stock = 12,
                Description = "Smart watch with fitness tracking, heart rate monitoring and notifications."
            }
        };

        // Display all products
        public IActionResult Index()
        {
            return View(products);
        }

        // Display complete product details
        public IActionResult Details(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // Display Create page
        public IActionResult Create()
        {
            return View();
        }

        // Add new product
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                product.Id = products.Count + 1;
                products.Add(product);

                return RedirectToAction("Index");
            }

            return View(product);
        }
    }
}