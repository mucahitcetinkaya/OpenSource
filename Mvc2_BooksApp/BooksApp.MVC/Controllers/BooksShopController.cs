using BooksApp.Business.Abstract;
using BooksApp.Entity.Concrete;
using BooksApp.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BooksApp.MVC.Controllers
{
    public class BooksShopController : Controller
    {
        private readonly IBookService _bookManager;

        public BooksShopController(IBookService bookManager)
        {
            _bookManager = bookManager;
        }

        public async Task<IActionResult> BookList(string categoryurl=null, string authorurl=null, string publisherurl=null)
        {
            List<Book> bookList = await _bookManager.GetAllActiveBooksAsync(categoryurl, authorurl, publisherurl);
            List<BookViewModel> bookViewModelList = bookList.Select(b => new BookViewModel
            {
                Id = b.Id,
                Name = b.Name,
                Price = b.Price,
                Url = b.Url,
                ImageUrl = b.ImageUrl,
                AuthorName = b.Author.FirstName + " " + b.Author.LastName,
                AuthorUrl = b.Author.Url,
                PublisherName = b.Publisher.Name,
                PublisherUrl = b.Publisher.Url
            }).ToList();
            return View(bookViewModelList);
        }
        public async Task<IActionResult> BookDetails(string url)
        {
            Book book = await _bookManager.GetBookByUrlAsync(url);
            BookDetailsViewModel bookDetailsViewModel = new BookDetailsViewModel
            {
                Id = book.Id,
                Name = book.Name,
                AuthorName = book.Author.FirstName + " " + book.Author.LastName,
                AuthorAbout = book.Author.About,
                AuthorUrl = book.Author.Url,
                Stock = book.Stock,
                Url = book.Url,
                ImageUrl = book.ImageUrl,
                Description = book.Description,
                EditionYear = book.EditionYear,
                EditionNumber = book.EditionNumber,
                PageCount = book.PageCount,
                Price = book.Price,
                PublisherName = book.Publisher.Name,
                PublisherUrl = book.Publisher.Url,
                Categories = book.BookCategories.Select(bc => new CategoryViewModel
                {
                    Name = bc.Category.Name,
                    Url = bc.Category.Url
                }).ToList()
            };
            return View(bookDetailsViewModel);
        }
    }
    
}
