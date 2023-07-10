using Microsoft.AspNetCore.Mvc;
using MiniShopApp.Business.Abstract;
using MiniShopApp.Mvc.Models;

namespace MiniShopApp.Mvc.Controllers
{
    public class HomeController : Controller
    {

        private readonly ICategoryService _categoryManager;
        private readonly IProductService _productManager;
        public HomeController(ICategoryService categoryManager, IProductService productManager)
        {
            _categoryManager = categoryManager;
            _productManager = productManager;
        }
        public async Task<IActionResult> Index()
        {
            var productList = await _productManager.GetHomePageProductsAsync();
            return View(productList);
        }

    }
}