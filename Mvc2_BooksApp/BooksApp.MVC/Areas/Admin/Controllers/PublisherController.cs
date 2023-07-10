using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using BooksApp.Business.Abstract;
using BooksApp.Core;
using BooksApp.Core.Models;
using BooksApp.Entity.Concrete;
using BooksApp.MVC.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BooksApp.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class PublisherController : Controller
    {
        #region DI
        private readonly IPublisherService _publisherManager;
        private readonly IBookService _bookManager;
        private readonly INotyfService _notyf;

        public PublisherController(IPublisherService publisherManager, INotyfService notyf, IBookService bookManager)
        {
            _publisherManager = publisherManager;
            _notyf = notyf;
            _bookManager = bookManager;
        }
        #endregion
        #region Listeleme
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Publisher> publisherList = await _publisherManager.GetAllPublishersAsync(false);
            List<PublisherViewModel> publisherViewModelList = publisherList
                .Select(p => new PublisherViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    CreatedDate = p.CreatedDate,
                    ModifiedDate = p.ModifiedDate,
                    IsActive = p.IsActive,
                    City = p.City,
                    Country = p.Country,
                    Phone = p.Phone,
                    Url = p.Url
                }).ToList();
            PublisherListViewModel model = new PublisherListViewModel
            {
                PublisherViewModelList = publisherViewModelList,
                SourceAction = "Index"
            };
            return View(model);
        }
        #endregion
        #region Yeni Yayınevi
        [HttpGet]
        public IActionResult Create()
        {
            List<SelectListItem> cities = Jobs.GetCities().Select(x => new SelectListItem
            {
                Text = x.Il,
                Value = x.Il
            }).ToList();
            PublisherAddViewModel publisherAddViewModel = new PublisherAddViewModel
            {
                Cities = cities
            };
            return View(publisherAddViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PublisherAddViewModel publisherAddViewModel)
        {
            if (ModelState.IsValid)
            {

                Publisher publisher = new Publisher
                {
                    Name = publisherAddViewModel.Name,
                    IsActive = publisherAddViewModel.IsActive,
                    City = publisherAddViewModel.City,
                    Country = publisherAddViewModel.Country,
                    Url = Jobs.GetUrl(publisherAddViewModel.Name),
                    Phone = publisherAddViewModel.Phone

                };
                await _publisherManager.CreateAsync(publisher);
                _notyf.Success("İşlem başarıyla tamamlanmıştır");
                return RedirectToAction("Index");
            }
            List<SelectListItem> cities = Jobs.GetCities().Select(x => new SelectListItem
            {
                Text = x.Il,
                Value = x.Il
            }).ToList();
            publisherAddViewModel.Cities = cities;
            return View(publisherAddViewModel);
        }

        #endregion
        #region Yayınevi Güncelleme
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Publisher publisher = await _publisherManager.GetByIdAsync(id);
            if (publisher == null)
            {
                return NotFound();
            }
            List<SelectListItem> cities = Jobs.GetCities().Select(x => new SelectListItem
            {
                Text = x.Il,
                Value = x.Il
            }).ToList();
            PublisherEditViewModel publisherEditViewModel = new PublisherEditViewModel
            {
                Id = publisher.Id,
                Name = publisher.Name,
                Phone = publisher.Phone,
                City = publisher.City,
                Country = publisher.Country,
                IsActive = publisher.IsActive,
                IsDeleted = publisher.IsDeleted,
                Cities = cities
            };
            return View(publisherEditViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(PublisherEditViewModel publisherEditViewModel)
        {

            if (ModelState.IsValid)
            {
                Publisher publisher = await _publisherManager.GetByIdAsync(publisherEditViewModel.Id);
                publisher.Name = publisherEditViewModel.Name;
                publisher.Phone = publisherEditViewModel.Phone;
                publisher.City = publisherEditViewModel.City;
                publisher.IsActive = publisherEditViewModel.IsActive;
                publisher.IsDeleted = publisherEditViewModel.IsDeleted;
                publisherEditViewModel.Url = Jobs.GetUrl(publisherEditViewModel.Name);
                publisher.Url = publisherEditViewModel.Url;
                publisher.ModifiedDate = DateTime.Now;

                _publisherManager.Update(publisher);
                _notyf.Success("Güncelleme başarıyla tamamlanmıştır.", 5);
                return RedirectToAction("Index");
            }
            List<SelectListItem> cities = Jobs.GetCities().Select(x => new SelectListItem
            {
                Text = x.Il,
                Value = x.Il
            }).ToList();
            publisherEditViewModel.Cities = cities;
            return View(publisherEditViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateIsActive(int id)
        {
            Publisher publisher = await _publisherManager.GetByIdAsync(id);
            if (publisher == null)
            {
                return NotFound();
            }
            publisher.IsActive = !publisher.IsActive;
            publisher.ModifiedDate = DateTime.Now;
            _publisherManager.Update(publisher);
            return RedirectToAction("Index");
        }
        #endregion
        #region Yayınevi Kalıcı Silme
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Publisher publisher = await _publisherManager.GetByIdAsync(id);
            if (publisher == null) return NotFound();
            PublisherDeleteViewModel publisherDeleteViewModel = new PublisherDeleteViewModel
            {
                Id = publisher.Id,
                Name = publisher.Name,
                Url = publisher.Url,
                IsActive = publisher.IsActive,
                IsDeleted = publisher.IsDeleted,
                Phone = publisher.Phone,
                City = publisher.City,
                Country = publisher.Country,
                CreatedDate = publisher.CreatedDate,
                ModifiedDate = publisher.ModifiedDate
            };
            return View(publisherDeleteViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> HardDelete(int id)
        {
            Publisher publisher = await _publisherManager.GetByIdAsync(id);
            if (publisher == null) return NotFound();
            _publisherManager.Delete(publisher);
            await _bookManager.UpdatePublisherOfBooks();
            return RedirectToAction("Index");
        }
        #endregion
        #region Yayınevi Soft Silme
        public async Task<IActionResult> SoftDelete(int id)
        {
            Publisher publisher = await _publisherManager.GetByIdAsync(id);
            if (publisher == null)
            {
                return NotFound();
            }
            publisher.IsDeleted = !publisher.IsDeleted;
            publisher.ModifiedDate = DateTime.Now;
            _publisherManager.Update(publisher);
            string message = publisher.IsDeleted ? "Kayıt silinmiştir. Geri almak için ilgili bölüme geçiniz." : "Kayıt geri alınmıştır.";
            _notyf.Success(message);
            return publisher.IsDeleted ? RedirectToAction("Index") : RedirectToAction("DeletedIndex");
        }
        #endregion
        #region Silinmiş Yayınlevleri Listeleme
        [HttpGet]
        public async Task<IActionResult> DeletedIndex()
        {
            List<Publisher> publisherList = await _publisherManager.GetAllPublishersAsync(true);
            List<PublisherViewModel> publisherViewModelList = publisherList
                .Select(p => new PublisherViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    CreatedDate = p.CreatedDate,
                    ModifiedDate = p.ModifiedDate,
                    IsActive = p.IsActive,
                    City = p.City,
                    Country = p.Country,
                    Phone = p.Phone,
                    Url = p.Url
                }).ToList();
            PublisherListViewModel model = new PublisherListViewModel
            {
                PublisherViewModelList = publisherViewModelList,
                SourceAction = "DeletedIndex"
            };
            return View("Index",model);
        }
        #endregion

    }
}