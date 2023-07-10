using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BooksApp.MVC.Models;
using BooksApp.Business.Abstract;
using BooksApp.Entity.Concrete;

namespace BooksApp.MVC.Controllers;

public class HomeController : Controller
{
    private readonly IBookService _bookManager;

    public HomeController(IBookService bookManager)
    {
        _bookManager = bookManager;
    }

    public async Task<IActionResult> Index()
    {
        List<Book> bookList = await _bookManager.GetBooksWithFullDataAsync(true,true);

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

}
