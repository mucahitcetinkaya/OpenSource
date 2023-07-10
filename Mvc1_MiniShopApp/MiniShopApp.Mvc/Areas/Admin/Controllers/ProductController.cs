using Microsoft.AspNetCore.Mvc;
using MiniShopApp.Business.Abstract;

namespace MiniShopApp.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productManager;

        public ProductController(IProductService productManager)
        {
            _productManager = productManager;
        }

        public async Task<IActionResult> Index()
        {
            var productList = await _productManager.GetAllAsync();
            return View(productList);
        }
    }
}
