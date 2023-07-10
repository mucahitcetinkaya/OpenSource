using BooksApp.Business.Abstract;
using BooksApp.Entity.Concrete;
using BooksApp.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BooksApp.MVC.ViewComponents
{
    public class AuthorsViewComponent: ViewComponent
    {
        private readonly IAuthorService _authorManager;

        public AuthorsViewComponent(IAuthorService authorManager)
        {
            _authorManager = authorManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Author> authorList = await _authorManager.GetAllAsync();
            List<AuthorViewModel> authorViewModelList = authorList.Select(a => new AuthorViewModel
            {
                Name=a.FirstName + " " + a.LastName,
                Url=a.Url
            }).ToList();
            return View(authorViewModelList);
        }
    }
}
