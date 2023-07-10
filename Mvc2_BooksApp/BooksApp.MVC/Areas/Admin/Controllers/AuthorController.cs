using AspNetCoreHero.ToastNotification.Abstractions;
using BooksApp.Business.Abstract;
using BooksApp.Business.Concrete;
using BooksApp.Core;
using BooksApp.Entity.Concrete;
using BooksApp.MVC.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BooksApp.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorManager;
        private readonly IBookService _bookManager;
        private readonly INotyfService _notyf;

        public AuthorController(IAuthorService authorManager, INotyfService notyf, IBookService bookManager)
        {
            _authorManager = authorManager;
            _notyf = notyf;
            _bookManager = bookManager;
        }
        #region Listeleme
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Author> authorList = await _authorManager.GetAllAuthorsAsync(false);
            List<AuthorViewModel> authorViewModelList = authorList
                .Select(a => new AuthorViewModel
                {
                    Id = a.Id,
                    Name = a.FirstName + " " + a.LastName,
                    CreatedDate = a.CreatedDate,
                    ModifiedDate = a.ModifiedDate,
                    About = a.About,
                    IsActive = a.IsActive,
                    IsAlive = a.IsAlive,
                    Url = a.Url,
                    PhotoUrl = a.PhotoUrl,
                    BirthOfYear = a.BirthOfYear
                }).ToList();
            AuthorListViewModel model = new AuthorListViewModel
            {
                AuthorViewModelList = authorViewModelList,
                SourceAction = "Index"
            };
            return View(model);
        }
        #endregion
        #region Yeni Yazar
        [HttpGet]
        public IActionResult Create()
        {
            List<int> years = Jobs.GetYears(0, 2005);
            AuthorAddViewModel authorAddViewModel = new AuthorAddViewModel
            {
                Years = years.Select(y => new SelectListItem
                {
                    Text = y.ToString(),
                    Value = y.ToString()
                }).ToList()
            };
            return View(authorAddViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AuthorAddViewModel authorAddViewModel)
        {
            if (ModelState.IsValid)
            {
                string name = authorAddViewModel.FirstName + " " + authorAddViewModel.LastName;
                Author author = new Author
                {
                    FirstName = authorAddViewModel.FirstName,
                    LastName = authorAddViewModel.LastName,
                    About = authorAddViewModel.About,
                    IsActive = authorAddViewModel.IsActive,
                    IsAlive = authorAddViewModel.IsAlive,
                    BirthOfYear = authorAddViewModel.BirthOfYear,
                    Url = Jobs.GetUrl(name),
                    PhotoUrl = "default-profile.jpg"

                };
                await _authorManager.CreateWithUrl(author);
                _notyf.Success("Yazar kaydı başarıyla tamamlanmıştır.");
                return RedirectToAction("Index");
            }
            List<int> years = Jobs.GetYears(0,2005);
            authorAddViewModel.Years = years.Select(y => new SelectListItem
            {
                Text = y.ToString(),
                Value = y.ToString()
            }).ToList();
            return View(authorAddViewModel);
        }

        #endregion
        #region Yazar Güncelleme
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Author author = await _authorManager.GetByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            var years = Jobs.GetYears(0, 2005);
            AuthorEditViewModel authorEditViewModel = new AuthorEditViewModel
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                About = author.About,
                BirthOfYear = author.BirthOfYear,
                IsAlive = author.IsAlive,
                IsActive = author.IsActive,
                IsDeleted = author.IsDeleted,
                Url = author.Url,
                PhotoUrl=author.PhotoUrl,
                Years = years.Select(y => new SelectListItem
                {
                    Text = y.ToString(),
                    Value = y.ToString(),
                    Selected = author.BirthOfYear == y ? true : false
                }).ToList()
            };

            return View(authorEditViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(AuthorEditViewModel authorEditViewModel)
        {
            if (ModelState.IsValid)
            {
                Author author = await _authorManager.GetByIdAsync(authorEditViewModel.Id);
                if (author == null) { return NotFound(); }
                string photoUrl="";
                string url = Jobs.GetUrl(authorEditViewModel.FirstName + "-" + authorEditViewModel.LastName);
                if (authorEditViewModel.PhotoFile==null)
                {
                    photoUrl = author.PhotoUrl;
                }
                else
                {
                    photoUrl = Jobs.UploadImage(authorEditViewModel.PhotoFile, url, "authors");
                }
                author.FirstName = authorEditViewModel.FirstName;
                author.LastName = authorEditViewModel.LastName;
                author.About = authorEditViewModel.About;
                author.BirthOfYear = authorEditViewModel.BirthOfYear;
                author.IsActive = authorEditViewModel.IsActive;
                author.IsDeleted = authorEditViewModel.IsDeleted;
                author.IsAlive = authorEditViewModel.IsAlive;
                authorEditViewModel.Url = url;
                author.Url = authorEditViewModel.Url;
                author.PhotoUrl = photoUrl;
                author.ModifiedDate = DateTime.Now;
                _authorManager.Update(author);
                _notyf.Success("Yazar bilgisi başarıyla güncellenmiştir.", 2);
                return RedirectToAction("Index");
            }
            List<int> years = Jobs.GetYears(0, 2005);
            authorEditViewModel.Years = years.Select(y => new SelectListItem
            {
                Text = y.ToString(),
                Value = y.ToString(),
                Selected = authorEditViewModel.BirthOfYear == y ? true : false
            }).ToList();
            return View(authorEditViewModel);
        }
        public async Task<IActionResult> UpdateIsActive(int id)
        {
            Author author = await _authorManager.GetByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            author.IsActive = !author.IsActive;
            author.ModifiedDate = DateTime.Now;
            _authorManager.Update(author);
            string isActive = author.IsActive ? "Aktif" : "Pasif";
            _notyf.Success($"Yazar başarıyla {isActive} duruma getirilmiştir.");
            return RedirectToAction("Index");
        }
        #endregion
        #region Yazar Kalıcı Silme
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Author author = await _authorManager.GetByIdAsync(id);
            if (author == null) return NotFound();
            AuthorDeleteViewModel authorDeleteViewModel = new AuthorDeleteViewModel
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                About = author.About,
                Url = author.Url,
                IsActive = author.IsActive,
                IsDeleted = author.IsDeleted,
                IsAlive = author.IsDeleted,
                CreatedDate = author.CreatedDate,
                ModifiedDate = author.ModifiedDate
            };
            return View(authorDeleteViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> HardDelete(int id)
        {
            Author author = await _authorManager.GetByIdAsync(id);
            if (author == null) return NotFound();
            _authorManager.Delete(author);
            await _bookManager.UpdateAuthorOfBooks();
            return RedirectToAction("Index");
        }
        #endregion
        #region Yazar Soft Silme
        public async Task<IActionResult> SoftDelete(int id)
        {
            Author author = await _authorManager.GetByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            author.IsDeleted = !author.IsDeleted;
            author.ModifiedDate = DateTime.Now;
            _authorManager.Update(author);
            string message = author.IsDeleted ? "Kayıt silinmiştir. Geri almak için ilgili bölüme geçiniz." : "Kayıt geri alınmıştır.";
            _notyf.Success(message);
            return author.IsDeleted ? RedirectToAction("Index") : RedirectToAction("DeletedIndex");
        }
        #endregion
        #region Silinmiş Yazarları Listeleme
        [HttpGet]
        public async Task<IActionResult> DeletedIndex()
        {
            List<Author> authorList = await _authorManager.GetAllAuthorsAsync(true);
            List<AuthorViewModel> authorViewModelList = authorList
                .Select(a => new AuthorViewModel
                {
                    Id = a.Id,
                    Name = a.FirstName + " " + a.LastName,
                    CreatedDate = a.CreatedDate,
                    ModifiedDate = a.ModifiedDate,
                    About = a.About,
                    IsActive = a.IsActive,
                    IsAlive = a.IsAlive,
                    Url = a.Url,
                    PhotoUrl = a.PhotoUrl,
                    BirthOfYear = a.BirthOfYear
                }).ToList();
            AuthorListViewModel model = new AuthorListViewModel
            {
                AuthorViewModelList = authorViewModelList,
                SourceAction = "DeletedIndex"
            };
            return View("Index",model);
        }
        #endregion

    }
}
