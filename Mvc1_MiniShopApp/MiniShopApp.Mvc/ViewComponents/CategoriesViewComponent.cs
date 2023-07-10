using Microsoft.AspNetCore.Mvc;
using MiniShopApp.Business.Abstract;

namespace MiniShopApp.Mvc.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryManager;
        public CategoriesViewComponent(ICategoryService categoryManager)
        {
            _categoryManager = categoryManager;
        }
        public async Task<IViewComponentResult> InvokeAsync(){
            if (RouteData.Values["categoryUrl"]!=null)
            {
                ViewBag.SelectedCategory = RouteData.Values["categoryUrl"];
            }
            var categories = await _categoryManager.GetActiveCategoriesAsync();
            return View(categories);
        }
    }
}