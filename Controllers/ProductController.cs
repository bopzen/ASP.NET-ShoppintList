using Microsoft.AspNetCore.Mvc;
using ShoppintList.Data;
using ShoppintList.Data.Models;
using ShoppintList.Models.Product;

namespace ShoppintList.Controllers
{
    public class ProductController : Controller
    {
        private readonly ShoppingListDbContext _data;
        public ProductController(ShoppingListDbContext data)
        {
            _data = data;
        }

        public IActionResult All()
        {
            var products = _data
                .Products
                .Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                })
                .ToList();
            return View(products);
        }

        [HttpPost]
        public IActionResult Add(ProductFormModel model)
        {
            var product = new Product()
            {
                Name = model.Name
            };

            _data.Products.Add(product);
            _data.SaveChanges();

            return RedirectToAction("All");
        }
    }
}
