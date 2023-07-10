using AspNetCoreHero.ToastNotification.Abstractions;
using BooksApp.Business.Abstract;
using BooksApp.Core;
using BooksApp.Entity.Concrete;
using BooksApp.MVC.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace BooksApp.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BookController : Controller
    {
        private readonly IBookService _bookManager;
        private readonly IAuthorService _authorManager;
        private readonly IPublisherService _publisherManager;
        private readonly ICategoryService _categoryManager;
        private readonly INotyfService _notyf;

        public BookController(IBookService bookManager, IAuthorService authorManager, IPublisherService publisherManager, ICategoryService categoryManager, INotyfService notyf)
        {
            _bookManager = bookManager;
            _authorManager = authorManager;
            _publisherManager = publisherManager;
            _categoryManager = categoryManager;
            _notyf = notyf;
        }

        #region Listeleme
        public async Task<IActionResult> Index()
        {
            List<Book> books = await _bookManager.GetAllBooksWithAuthorAndPublisher(false);
            List<BookViewModel> bookViewModelList = books
                .Select(b => new BookViewModel
                {
                    Id = b.Id,
                    Name = b.Name,
                    Price = b.Price,
                    ImageUrl = b.ImageUrl,
                    IsActive = b.IsActive,
                    AuthorName = b.Author.FirstName + " " + b.Author.LastName,
                    PublisherName = b.Publisher.Name
                }).ToList();
            BookListViewModel model = new BookListViewModel
            {
                BookViewModelList = bookViewModelList,
                SourceAction = "Index"
            };
            return View(model);
        }

        #endregion
        #region Yardımcı Metotlar(Action Olmayanlar)
        [NonAction]
        private async Task<List<SelectListItem>> GetAuthorSelectList()
        {
            List<Author> authorList = await _authorManager.GetAllAuthorsAsync(false, true);
            List<SelectListItem> authorViewModelList = authorList.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.FirstName + " " + a.LastName
            }).ToList();
            return authorViewModelList;
        }

        [NonAction]
        private async Task<List<SelectListItem>> GetPublisherSelectList()
        {
            List<Publisher> publisherList = await _publisherManager.GetAllPublishersAsync(false, true);
            List<SelectListItem> publisherViewModelList = publisherList.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name
            }).ToList();
            return publisherViewModelList;
        }
        [NonAction]
        private async Task<List<CategoryViewModel>> GetCategoryList()
        {
            List<Category> categoryList = await _categoryManager.GetAllCategoriesAsync(false, true);
            List<CategoryViewModel> categoryViewModelList = categoryList.Select(c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
            return categoryViewModelList;
        }
        [NonAction]
        private List<SelectListItem> GetYearList(int startYear, int endYear)
        {
            List<int> years = Jobs.GetYears(startYear, endYear);
            List<SelectListItem> yearList = years.Select(y => new SelectListItem
            {
                Value = y.ToString(),
                Text = y.ToString()
            }).ToList();
            return yearList;
        }
        #endregion
        #region Yeni Kitap
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var authorViewModelList = await GetAuthorSelectList();
            var publisherViewModelList = await GetPublisherSelectList();
            var categoryViewModelList = await GetCategoryList();
            var yearList = GetYearList(1900, DateTime.Now.Year);
            BookAddViewModel bookAddViewModel = new BookAddViewModel
            {
                AuthorList = authorViewModelList,
                PublisherList = publisherViewModelList,
                CategoryList = categoryViewModelList,
                YearList = yearList
            };
            return View(bookAddViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(BookAddViewModel bookAddViewModel)
        {
            if (ModelState.IsValid && bookAddViewModel.SelectedCategoryIds.Count > 0)
            {
                var url = Jobs.GetUrl(bookAddViewModel.Name);
                Book book = new Book
                {
                    Name = bookAddViewModel.Name,
                    Description = bookAddViewModel.Description,
                    EditionNumber = bookAddViewModel.EditionNumber,
                    EditionYear = bookAddViewModel.EditionYear,
                    IsActive = bookAddViewModel.IsActive,
                    IsHome = bookAddViewModel.IsHome,
                    PageCount = bookAddViewModel.PageCount,
                    Stock = bookAddViewModel.Stock,
                    ModifiedDate = DateTime.Now,
                    AuthorId = bookAddViewModel.AuthorId,
                    PublisherId = bookAddViewModel.PublisherId,
                    Price = bookAddViewModel.Price,
                    Url = url,
                    ImageUrl = Jobs.UploadImage(bookAddViewModel.ImageFile, url, "books")
                };
                await _bookManager.CreateBookAsync(book, bookAddViewModel.SelectedCategoryIds);
                _notyf.Success("Kayıt işlemi başarıyla tamamlanmıştır.");
                return RedirectToAction("Index");
            }
            if (bookAddViewModel.SelectedCategoryIds.Count == 0)
            {
                ViewBag.CategoryErrorMessage = "En az bir kategori seçilmelidir.";
            }
            var authorViewModelList = await GetAuthorSelectList();
            var publisherViewModelList = await GetPublisherSelectList();
            var categoryViewModelList = await GetCategoryList();
            var yearList = GetYearList(1900, DateTime.Now.Year);
            bookAddViewModel.AuthorList = authorViewModelList;
            bookAddViewModel.PublisherList = publisherViewModelList;
            bookAddViewModel.CategoryList = categoryViewModelList;
            bookAddViewModel.YearList = yearList;
            return View(bookAddViewModel);
        }

        #endregion
        #region Kitap Güncelleme
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Book book = await _bookManager.GetBookByIdAsync(id);
            if (book==null)
            {
                _notyf.Warning("Sadece aktif ve silinmemiş kitaplar düzenlenebilir.");
                return RedirectToAction("Index");
            }
            BookEditViewModel bookEditViewModel = new BookEditViewModel
            {
                Id = book.Id,
                Name = book.Name,
                Stock = book.Stock,
                Description = book.Description,
                AuthorId = book.AuthorId,
                EditionNumber = book.EditionNumber,
                EditionYear = book.EditionYear,
                ImageUrl = book.ImageUrl,
                IsActive = book.IsActive,
                IsDeleted = book.IsDeleted,
                IsHome = book.IsHome,
                PageCount = book.PageCount,
                Price = book.Price,
                PublisherId = book.PublisherId,
                SelectedCategoryIds = book.BookCategories.Select(bc => bc.CategoryId).ToList(),
                AuthorList = await GetAuthorSelectList(),
                CategoryList = await GetCategoryList(),
                PublisherList = await GetPublisherSelectList(),
                YearList = GetYearList(1900, DateTime.Now.Year)
            };
            return View(bookEditViewModel);
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(BookEditViewModel bookEditViewModel)
        {
            if (ModelState.IsValid && bookEditViewModel.SelectedCategoryIds.Count()>0)
            {
                Book book = new Book();
                var url = Jobs.GetUrl(bookEditViewModel.Name);
                book.Id= bookEditViewModel.Id;
                book.Name=bookEditViewModel.Name;
                book.Description=bookEditViewModel.Description;
                book.Price = bookEditViewModel.Price;
                book.PageCount = bookEditViewModel.PageCount;
                book.EditionYear = bookEditViewModel.EditionYear;
                book.EditionNumber = bookEditViewModel.EditionNumber;
                book.Stock = bookEditViewModel.Stock;
                book.IsActive = bookEditViewModel.IsActive;
                book.IsHome = bookEditViewModel.IsHome;
                book.IsDeleted = bookEditViewModel.IsDeleted;
                book.AuthorId = bookEditViewModel.AuthorId;
                book.PublisherId = bookEditViewModel.PublisherId;
                book.Url = url;
                
                book.BookCategories = bookEditViewModel.SelectedCategoryIds.Select(sc => new BookCategory
                {
                    BookId = book.Id,
                    CategoryId = sc
                }).ToList();
                book.ImageUrl = bookEditViewModel.ImageFile == null ? bookEditViewModel.ImageUrl : Jobs.UploadImage(bookEditViewModel.ImageFile, url, "books");
                _bookManager.UpdateBook(book);
                _notyf.Success("Güncelleme işlemi başarıyla tamamlanmıştır.");
                return RedirectToAction("Index");
            }
            var authorViewModelList = await GetAuthorSelectList();
            var publisherViewModelList = await GetPublisherSelectList();
            var categoryViewModelList = await GetCategoryList();
            var yearList = GetYearList(1900, DateTime.Now.Year);
            bookEditViewModel.AuthorList = authorViewModelList;
            bookEditViewModel.PublisherList = publisherViewModelList;
            bookEditViewModel.CategoryList = categoryViewModelList;
            bookEditViewModel.YearList = yearList;
            return View(bookEditViewModel);
        }
        public async Task<IActionResult> UpdateIsActive(int id)
        {
            Book book = await _bookManager.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            book.IsActive = !book.IsActive;
            book.ModifiedDate = DateTime.Now;
            _bookManager.Update(book);
            string isActive = book.IsActive ? "Aktif" : "Pasif";
            _notyf.Success($"Kitap başarıyla {isActive} duruma getirilmiştir.");
            return RedirectToAction("Index");
        }
        #endregion
        #region Kitap Kalıcı Silme
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Book book = await _bookManager.GetBookByIdAsync(id);
            if (book == null) return NotFound();
            BookDeleteViewModel bookDeleteViewModel = new BookDeleteViewModel
            {
                Id = book.Id,
                Name = book.Name,
                AuthorName = book.Author.FirstName + " " + book.Author.LastName,
                PublisherName=book.Publisher.Name,
                Price = book.Price,
                EditionYear = book.EditionYear,
                EditionNumber=book.EditionNumber,
                IsActive = book.IsActive,
                IsHome = book.IsHome
            };
            return View(bookDeleteViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> HardDelete(int id)
        {
            Book book = await _bookManager.GetByIdAsync(id);
            if (book == null) return NotFound();
            _bookManager.Delete(book);
            return RedirectToAction("Index");
        }
        #endregion
        #region Kitap Soft Silme
        public async Task<IActionResult> SoftDelete(int id)
        {
            Book book = await _bookManager.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            book.IsDeleted = !book.IsDeleted;
            book.ModifiedDate = DateTime.Now;
            _bookManager.Update(book);
            string message = book.IsDeleted ? "Kayıt silinmiştir. Geri almak için ilgili bölüme geçiniz." : "Kayıt geri alınmıştır.";
            _notyf.Success(message);
            return book.IsDeleted ? RedirectToAction("Index") : RedirectToAction("DeletedIndex");
        }
        #endregion
        #region Silinmiş Kitap Listeleme
        public async Task<IActionResult> DeletedIndex()
        {
            List<Book> books = await _bookManager.GetAllBooksWithAuthorAndPublisher(true);
            List<BookViewModel> bookViewModelList = books
                .Select(b => new BookViewModel
                {
                    Id = b.Id,
                    Name = b.Name,
                    Price = b.Price,
                    ImageUrl = b.ImageUrl,
                    IsActive = b.IsActive,
                    AuthorName = b.Author.FirstName + " " + b.Author.LastName,
                    PublisherName = b.Publisher.Name
                }).ToList();
            BookListViewModel model = new BookListViewModel
            {
                BookViewModelList = bookViewModelList,
                SourceAction = "DeletedIndex"
            };
            return View("Index", model);
        }

        #endregion

    }
}
