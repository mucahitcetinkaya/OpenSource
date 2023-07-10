using Microsoft.AspNetCore.Mvc;
using MiniShopApp.Business.Abstract;
using MiniShopApp.Core;
using MiniShopApp.Entity.Concrete;
using MiniShopApp.Mvc.Areas.Admin.Models;

namespace MiniShopApp.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryManager;

        public CategoryController(ICategoryService categoryManager)
        {
            _categoryManager = categoryManager;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryManager.GetAllAsync();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryAddViewModel categoryAddViewModel)
        {
            //Veri tabanına gelen bilgilerden üretilen Category gönderilerek kaydedilir.
            Category category = new Category
            {
                Name = categoryAddViewModel.Name,
                Description = categoryAddViewModel.Description,
                IsActive = categoryAddViewModel.IsActive,
                Url = Jobs.GetUrl(categoryAddViewModel.Name)
            };
            await _categoryManager.CreateAsync(category);
            return RedirectToAction("Index");
        }
    }
}
