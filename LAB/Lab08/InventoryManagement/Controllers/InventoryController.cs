using InventoryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
namespace InventoryManagement.Controllers
{
    public class InventoryController : Controller
    {
        private readonly string connectionString;

        public InventoryController(IConfiguration configuration)
        {
            connectionString =
                configuration.GetConnectionString("InventoryConnection")!;
        }
        // READ: Display all products
        public IActionResult Index()
        {
            List<Product> products = new();
            using SqlConnection con = new(connectionString);
            string query = "SELECT * FROM Products ORDER BY ProductID";
            using SqlCommand cmd = new(query, con);
            con.Open();
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                products.Add(new Product
                {
                    ProductID = (int)reader["ProductID"],
                    ProductName = reader["ProductName"].ToString()!,
                    Category = reader["Category"]?.ToString() ?? "",
                    Quantity = (int)reader["Quantity"],
                    Price = (decimal)reader["Price"]
                });
            }
            return View(products);
        }
        // CREATE: Display form
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        // CREATE: Save product
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);
            using SqlConnection con = new(connectionString);
            string query = @"INSERT INTO Products
                (ProductName, Category, Quantity, Price)
                VALUES (@Name, @Category, @Quantity, @Price)";
            using SqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@Name", product.ProductName);
            cmd.Parameters.AddWithValue("@Category", product.Category);
            cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            con.Open();
            cmd.ExecuteNonQuery();
            return RedirectToAction(nameof(Index));
        }
        // UPDATE: Display existing product
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Product? product = null;
            using SqlConnection con = new(connectionString);
            string query = "SELECT * FROM Products WHERE ProductID=@ID";
            using SqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@ID", id);
            con.Open();
            using SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                product = new Product
                {
                    ProductID = (int)reader["ProductID"],
                    ProductName = reader["ProductName"].ToString()!,
                    Category = reader["Category"]?.ToString() ?? "",
                    Quantity = (int)reader["Quantity"],
                    Price = (decimal)reader["Price"]
                };
            }
            if (product == null)
                return NotFound();
            return View(product);
        }
        // UPDATE: Save changes
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);
            using SqlConnection con = new(connectionString);
            string query = @"UPDATE Products SET
                ProductName=@Name, Category=@Category,
                Quantity=@Quantity, Price=@Price
                WHERE ProductID=@ID";
            using SqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@ID", product.ProductID);
            cmd.Parameters.AddWithValue("@Name", product.ProductName);
            cmd.Parameters.AddWithValue("@Category", product.Category);
            cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            con.Open();
            if (cmd.ExecuteNonQuery() == 0)
                return NotFound();
            return RedirectToAction(nameof(Index));
        }
        // DELETE: Confirmation page
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Product? product = null;
            using SqlConnection con = new(connectionString);
            using SqlCommand cmd = new(
                "SELECT * FROM Products WHERE ProductID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", id);
            con.Open();
            using SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                product = new Product
                {
                    ProductID = (int)reader["ProductID"],
                    ProductName = reader["ProductName"].ToString()!,
                    Category = reader["Category"]?.ToString() ?? "",
                    Quantity = (int)reader["Quantity"],
                    Price = (decimal)reader["Price"]
                };
            }
            if (product == null)
                return NotFound();
            return View(product);
        }
        // DELETE: Remove product
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            using SqlConnection con = new(connectionString);
            using SqlCommand cmd = new(
                "DELETE FROM Products WHERE ProductID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", id);
            con.Open();
            if (cmd.ExecuteNonQuery() == 0)
                return NotFound();
            return RedirectToAction(nameof(Index));
        }
    }
}
