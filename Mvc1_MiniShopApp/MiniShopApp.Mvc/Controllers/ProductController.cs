using Microsoft.AspNetCore.Mvc;
using MiniShopApp.Business.Abstract;
using MiniShopApp.Entity.Concrete;
using MiniShopApp.Mvc.Models;

namespace MiniShopApp.Mvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productManager;

        public ProductController(IProductService productManager)
        {
            _productManager = productManager;
        }

        public async Task<IActionResult> Index(string categoryUrl)
        {
            List<Product> products = await _productManager.GetActiveProductsAsync(categoryUrl);
            return View(products);
        }
        public async Task<IActionResult> Details(string url)
        {
            var product = await _productManager.GetProductByUrlAsync(url);
            var viewModel = new ProductViewModel
            {
                Id = product.Id,
                ModifiedDate = product.ModifiedDate,
                Name = product.Name,
                Properties = product.Properties,
                Price = product.Price,
                Url = product.Url,
                ImageUrl = product.ImageUrl,
                Categories = product
                    .ProductCategories
                    .Select(pc => pc.Category)
                    .ToList()
            };
            return View(viewModel);
        }
    }
}