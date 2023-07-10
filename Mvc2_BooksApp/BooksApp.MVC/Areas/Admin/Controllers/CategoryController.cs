﻿using AspNetCoreHero.ToastNotification.Abstractions;
using BooksApp.Business.Abstract;
using BooksApp.Core;
using BooksApp.Entity.Concrete;
using BooksApp.MVC.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BooksApp.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryManager;
        private readonly IBookService _bookManager;
        private readonly INotyfService _notyf;

        public CategoryController(ICategoryService categoryManager, INotyfService notyf, IBookService bookManager)
        {
            _categoryManager = categoryManager;
            _notyf = notyf;
            _bookManager = bookManager;
        }

        #region Listeleme
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Category> categoryList = await _categoryManager.GetAllCategoriesAsync(false);
            List<CategoryViewModel> categoryViewModelList = categoryList
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    CreatedDate = c.CreatedDate,
                    ModifiedDate = c.ModifiedDate,
                    Description = c.Description,
                    IsActive = c.IsActive,
                    Url = c.Url
                }).ToList();
            CategoryListViewModel model = new CategoryListViewModel
            {
                CategoryViewModelList = categoryViewModelList,
                SourceAction = "Index"
            };
            return View(model);
        }

        #endregion
        #region Yeni Kategori
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryAddViewModel categoryAddViewModel)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category
                {
                    Name = categoryAddViewModel.Name,
                    Description = categoryAddViewModel.Description,
                    IsActive = categoryAddViewModel.IsActive,
                    Url = Jobs.GetUrl(categoryAddViewModel.Name)
                };
                await _categoryManager.CreateAsync(category);
                _notyf.Success("Kayıt işlemi başarıyla tamamlanmıştır.");
                return RedirectToAction("Index");
            }
            return View(categoryAddViewModel);
        }

        #endregion
        #region Kategori Güncelleme
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Category category = await _categoryManager.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            CategoryEditViewModel categoryEditViewModel = new CategoryEditViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                IsActive = category.IsActive,
                IsDeleted = category.IsDeleted
            };
            return View(categoryEditViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CategoryEditViewModel categoryEditViewModel)
        {
            if (ModelState.IsValid)
            {
                Category category = await _categoryManager.GetByIdAsync(categoryEditViewModel.Id);
                category.Name = categoryEditViewModel.Name;
                category.Description = categoryEditViewModel.Description;
                category.IsActive = categoryEditViewModel.IsActive;
                category.IsDeleted = categoryEditViewModel.IsDeleted;
                categoryEditViewModel.Url = Jobs.GetUrl(categoryEditViewModel.Name);
                category.Url = categoryEditViewModel.Url;
                category.ModifiedDate = DateTime.Now;
                _categoryManager.Update(category);
                
                _notyf.Success("Güncelleme başarıyla tamamlanmıştır.");
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateIsActive(int id)
        {
            Category category = await _categoryManager.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            category.IsActive = !category.IsActive;
            category.ModifiedDate = DateTime.Now;
            _categoryManager.Update(category);
            return RedirectToAction("Index");
        }
        #endregion
        #region Kategori Kalıcı Silme
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Category category = await _categoryManager.GetByIdAsync(id);
            if (category == null) return NotFound();
            CategoryDeleteViewModel categoryDeleteViewModel = new CategoryDeleteViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                Url = category.Url,
                IsActive = category.IsActive,
                IsDeleted = category.IsDeleted,
                CreatedDate = category.CreatedDate,
                ModifiedDate = category.ModifiedDate
            };
            return View(categoryDeleteViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> HardDelete(int id)
        {
            Category category = await _categoryManager.GetByIdAsync(id);
            if (category == null) return NotFound();
            _categoryManager.Delete(category);
            await _bookManager.CheckBooksCategories();
            _notyf.Success("Kayıt veri tabanından kalıcı olarak silinmiştir.");
            return RedirectToAction("Index");
        }
        #endregion
        #region Kategori Soft Silme
        public async Task<IActionResult> SoftDelete(int id)
        {
            Category category = await _categoryManager.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            category.IsDeleted = !category.IsDeleted;
            category.ModifiedDate = DateTime.Now;
            _categoryManager.Update(category);
            string message = category.IsDeleted ? "Kayıt silinmiştir. Geri almak için ilgili bölüme geçiniz." : "Kayıt geri alınmıştır.";
            _notyf.Success(message);
            return category.IsDeleted ? RedirectToAction("Index") : RedirectToAction("DeletedIndex");
        }
        #endregion
        #region Geri Dönüşüm Kutusu
        public async Task<IActionResult> DeletedIndex()
        {
            List<Category> categoryList = await _categoryManager.GetAllCategoriesAsync(true);
            List<CategoryViewModel> categoryViewModelList = categoryList
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    CreatedDate = c.CreatedDate,
                    ModifiedDate = c.ModifiedDate,
                    Description = c.Description,
                    IsActive = c.IsActive,
                    Url = c.Url
                }).ToList();
            CategoryListViewModel model = new CategoryListViewModel
            {
                CategoryViewModelList = categoryViewModelList,
                SourceAction = "DeletedIndex"
            };
            return View("Index", model);
        }
        #endregion
    }
}
