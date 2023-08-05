using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using LessonWorld.Business.Abstract;
using LessonWorld.Core;
using LessonWorld.Core.Models;
using LessonWorld.Entity.Concrete;
using LessonWorld.Mvc.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LessonWorld.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class SchoolController : Controller
    {
        // DI
        private readonly ISchoolService _schoolManager;
        private readonly ILessonService _lessonManager;
        private readonly INotyfService _notyf;

        public SchoolController(ISchoolService schoolManager, INotyfService notyf, ILessonService lessonManager)
        {
            _schoolManager = schoolManager;
            _notyf = notyf;
            _lessonManager = lessonManager;
        }
       
        // Listeleme
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<School> schoolList = await _schoolManager.GetAllSchoolsAsync(false);
            List<SchoolViewModel> schoolViewModelList = schoolList
                .Select(s => new SchoolViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    CreatedDate = s.CreatedDate,
                    ModifiedDate = s.ModifiedDate,
                    IsActive = s.IsActive,
                    City = s.City,
                    Country = s.Country,
                    Phone = s.Phone,
                    Url = s.Url
                }).ToList();
            SchoolListViewModel model = new SchoolListViewModel
            {
                SchoolViewModelList = schoolViewModelList,
                SourceAction = "Index"
            };
            return View(model);
        }
        
        //Yeni Okul
        [HttpGet]
        public IActionResult Create()
        {
            List<SelectListItem> cities = Jobs.GetCities().Select(x => new SelectListItem
            {
                Text = x.Il,
                Value = x.Il
            }).ToList();
            SchoolAddViewModel schoolAddViewModel = new SchoolAddViewModel
            {
                Cities = cities
            };
            return View(schoolAddViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SchoolAddViewModel schoolAddViewModel)
        {
            if (ModelState.IsValid)
            {

                School school = new School
                {
                    Name = schoolAddViewModel.Name,
                    IsActive = schoolAddViewModel.IsActive,
                    City = schoolAddViewModel.City,
                    Country = schoolAddViewModel.Country,
                    Url = Jobs.GetUrl(schoolAddViewModel.Name),
                    Phone = schoolAddViewModel.Phone

                };
                await _schoolManager.CreateAsync(school);
                _notyf.Success("İşlem başarıyla tamamlanmıştır");
                return RedirectToAction("Index");
            }
            List<SelectListItem> cities = Jobs.GetCities().Select(x => new SelectListItem
            {
                Text = x.Il,
                Value = x.Il
            }).ToList();
            schoolAddViewModel.Cities = cities;
            return View(schoolAddViewModel);
        }

        
        // Okul Güncelleme
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            School school = await _schoolManager.GetByIdAsync(id);
            if (school == null)
            {
                return NotFound();
            }
            List<SelectListItem> cities = Jobs.GetCities().Select(x => new SelectListItem
            {
                Text = x.Il,
                Value = x.Il
            }).ToList();
            SchoolEditViewModel schoolEditViewModel = new SchoolEditViewModel
            {
                Id = school.Id,
                Name = school.Name,
                Phone = school.Phone,
                City = school.City,
                Country = school.Country,
                IsActive = school.IsActive,
                IsDeleted = school.IsDeleted,
                Cities = cities
            };
            return View(schoolEditViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SchoolEditViewModel schoolEditViewModel)
        {

            if (ModelState.IsValid)
            {
                School school = await _schoolManager.GetByIdAsync(schoolEditViewModel.Id);
                school.Name = schoolEditViewModel.Name;
                school.Phone = schoolEditViewModel.Phone;
                school.City = schoolEditViewModel.City;
                school.Country = schoolEditViewModel.Country;
                school.IsActive = schoolEditViewModel.IsActive;
                school.IsDeleted = schoolEditViewModel.IsDeleted;
                schoolEditViewModel.Url = Jobs.GetUrl(schoolEditViewModel.Name);
                school.Url = schoolEditViewModel.Url;
                school.ModifiedDate = DateTime.Now;

                _schoolManager.Update(school);
                _notyf.Success("Güncelleme başarıyla tamamlanmıştır.", 5);
                return RedirectToAction("Index");
            }
            List<SelectListItem> cities = Jobs.GetCities().Select(x => new SelectListItem
            {
                Text = x.Il,
                Value = x.Il
            }).ToList();
            schoolEditViewModel.Cities = cities;
            return View(schoolEditViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateIsActive(int id)
        {
            School school = await _schoolManager.GetByIdAsync(id);
            if (school == null)
            {
                return NotFound();
            }
            school.IsActive = !school.IsActive;
            school.ModifiedDate = DateTime.Now;
            _schoolManager.Update(school);
            return RedirectToAction("Index");
        }
        
        // Okul Kalıcı Silme
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            School school = await _schoolManager.GetByIdAsync(id);
            if (school == null) return NotFound();
            SchoolDeleteViewModel schoolDeleteViewModel = new SchoolDeleteViewModel
            {
                Id = school.Id,
                Name = school.Name,
                Url = school.Url,
                IsActive = school.IsActive,
                IsDeleted = school.IsDeleted,
                Phone = school.Phone,
                City = school.City,
                Country = school.Country,
                CreatedDate = school.CreatedDate,
                ModifiedDate = school.ModifiedDate
            };
            return View(schoolDeleteViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> HardDelete(int id)
        {
            School school = await _schoolManager.GetByIdAsync(id);
            if (school == null) return NotFound();
            _schoolManager.Delete(school);
            await _lessonManager.UpdateSchoolOfLessons();
            return RedirectToAction("Index");
        }
        
        //  Okul Soft Silme
        public async Task<IActionResult> SoftDelete(int id)
        {
            School school = await _schoolManager.GetByIdAsync(id);
            if (school == null)
            {
                return NotFound();
            }
            school.IsDeleted = !school.IsDeleted;
            school.ModifiedDate = DateTime.Now;
            _schoolManager.Update(school);
            string message = school.IsDeleted ? "Kayıt silinmiştir. Geri almak için ilgili bölüme geçiniz." : "Kayıt geri alınmıştır.";
            _notyf.Success(message);
            return school.IsDeleted ? RedirectToAction("Index") : RedirectToAction("DeletedIndex");
        }
        
        // Silinmiş Okulları Listeleme
        [HttpGet]
        public async Task<IActionResult> DeletedIndex()
        {
            List<School> schoolList = await _schoolManager.GetAllSchoolsAsync(true);
            List<SchoolViewModel> schoolViewModelList = schoolList
                .Select(s => new SchoolViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    CreatedDate = s.CreatedDate,
                    ModifiedDate = s.ModifiedDate,
                    IsActive = s.IsActive,
                    City = s.City,
                    Country = s.Country,
                    Phone = s.Phone,
                    Url = s.Url
                }).ToList();
            SchoolListViewModel model = new SchoolListViewModel
            {
                SchoolViewModelList = schoolViewModelList,
                SourceAction = "DeletedIndex"
            };
            return View("Index",model);
        }
        

    }
}