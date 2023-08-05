using AspNetCoreHero.ToastNotification.Abstractions;
using LessonWorld.Business.Abstract;
using LessonWorld.Core;
using LessonWorld.Entity.Concrete;
using LessonWorld.Mvc.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace LessonWorld.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class LessonController : Controller
    {
        private readonly ILessonService _lessonManager;
        private readonly ITeacherService _teacherManager;
        private readonly ISchoolService _schoolManager;
        private readonly ICategoryService _categoryManager;
        private readonly INotyfService _notyf;

        public LessonController(ILessonService lessonManager, ITeacherService teacherManager, ISchoolService schoolManager, ICategoryService categoryManager, INotyfService notyf)
        {
            _lessonManager = lessonManager;
            _teacherManager = teacherManager;
            _schoolManager = schoolManager;
            _categoryManager = categoryManager;
            _notyf = notyf;
        }
        //Listeleme
        public async Task<IActionResult> Index()
        {
            List<Lesson> lessons = await _lessonManager.GetAllLessonsWithTeacherAndSchool(false);
            List<LessonViewModel> lessonViewModelList = lessons
                .Select(l => new LessonViewModel
                {
                    Id = l.Id,
                    Name = l.Name,
                    Price = l.Price,
                    ImageUrl = l.ImageUrl,
                    IsActive = l.IsActive,
                    TeacherName = l.Teacher.FirstName + " " + l.Teacher.LastName,
                    SchoolName = l.School.Name
                }).ToList();
            LessonListViewModel model = new LessonListViewModel
            {
                LessonViewModelList = lessonViewModelList,
                SourceAction = "Index"
            };
            return View(model);
        }

        // Yardımcı Metotlar(Action Olmayanlar)
        [NonAction]
        private async Task<List<SelectListItem>> GetTeacherSelectList()
        {
            List<Teacher> teacherList = await _teacherManager.GetAllTeachersAsync(false, true);
            List<SelectListItem> teacherViewModelList = teacherList.Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.FirstName + " " + t.LastName
            }).ToList();
            return teacherViewModelList;
        }

        [NonAction]
        private async Task<List<SelectListItem>> GetSchoolSelectList()
        {
            List<School> schoolList = await _schoolManager.GetAllSchoolsAsync(false, true);
            List<SelectListItem> schoolViewModelList = schoolList.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Name
            }).ToList();
            return schoolViewModelList;
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
       
        // Yeni Ders
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var teacherViewModelList = await GetTeacherSelectList();
            var schoolViewModelList = await GetSchoolSelectList();
            var categoryViewModelList = await GetCategoryList();
            var yearList = GetYearList(1900, DateTime.Now.Year);
            LessonAddViewModel lessonAddViewModel = new LessonAddViewModel
            {
                TeacherList = teacherViewModelList,
                SchoolList = schoolViewModelList,
                CategoryList = categoryViewModelList,
                YearList = yearList
            };
            return View(lessonAddViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(LessonAddViewModel lessonAddViewModel)
        {
            if (ModelState.IsValid && lessonAddViewModel.SelectedCategoryIds.Count > 0)
            {
                var url = Jobs.GetUrl(lessonAddViewModel.Name);
                Lesson lesson = new Lesson
                {
                    Name = lessonAddViewModel.Name,
                    Description = lessonAddViewModel.Description,
                    IsActive = lessonAddViewModel.IsActive,
                    IsHome = lessonAddViewModel.IsHome,
                    ModifiedDate = DateTime.Now,
                    TeacherId = lessonAddViewModel.TeacherId,
                    SchoolId = lessonAddViewModel.SchoolId,
                    Price = lessonAddViewModel.Price,
                    Url = url,
                    ImageUrl = Jobs.UploadImage(lessonAddViewModel.ImageFile, url, "lesson")
                };
                await _lessonManager.CreateLessonAsync(lesson, lessonAddViewModel.SelectedCategoryIds);
                _notyf.Success("Kayıt işlemi başarıyla tamamlanmıştır.");
                return RedirectToAction("Index");
            }
            if (lessonAddViewModel.SelectedCategoryIds.Count == 0)
            {
                ViewBag.CategoryErrorMessage = "En az bir kategori seçilmelidir.";
            }
            var teacherViewModelList = await GetTeacherSelectList();
            var schoolViewModelList = await GetSchoolSelectList();
            var categoryViewModelList = await GetCategoryList();
            var yearList = GetYearList(1900, DateTime.Now.Year);
            lessonAddViewModel.TeacherList = teacherViewModelList;
            lessonAddViewModel.SchoolList = schoolViewModelList;
            lessonAddViewModel.CategoryList = categoryViewModelList;
            lessonAddViewModel.YearList = yearList;
            return View(lessonAddViewModel);
        }

        
        // Ders Güncelleme
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Lesson lesson = await _lessonManager.GetLessonByIdAsync(id);
            if (lesson==null)
            {
                _notyf.Warning("Sadece aktif ve silinmemiş dersler düzenlenebilir.");
                return RedirectToAction("Index");
            }
            LessonEditViewModel lessonEditViewModel = new LessonEditViewModel
            {
                Id = lesson.Id,
                Name = lesson.Name,
                Description = lesson.Description,
                TeacherId = lesson.TeacherId,
                ImageUrl = lesson.ImageUrl,
                IsActive = lesson.IsActive,
                IsDeleted = lesson.IsDeleted,
                IsHome = lesson.IsHome,
                Price = lesson.Price,
                SchoolId = lesson.SchoolId,
                SelectedCategoryIds = lesson.LessonCategories.Select(lc => lc.CategoryId).ToList(),
                TeacherList = await GetTeacherSelectList(),
                CategoryList = await GetCategoryList(),
                SchoolList = await GetSchoolSelectList(),
                YearList = GetYearList(1900, DateTime.Now.Year)
            };
            return View(lessonEditViewModel);
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(LessonEditViewModel lessonEditViewModel)
        {
            if (ModelState.IsValid && lessonEditViewModel.SelectedCategoryIds.Count()>0)
            {
                Lesson lesson = new Lesson();
                var url = Jobs.GetUrl(lessonEditViewModel.Name);
                lesson.Id= lessonEditViewModel.Id;
                lesson.Name=lessonEditViewModel.Name;
                lesson.Description=lessonEditViewModel.Description;
                lesson.Price = lessonEditViewModel.Price;
                lesson.IsActive = lessonEditViewModel.IsActive;
                lesson.IsHome = lessonEditViewModel.IsHome;
                lesson.IsDeleted = lessonEditViewModel.IsDeleted;
                lesson.TeacherId = lessonEditViewModel.TeacherId;
                lesson.SchoolId = lessonEditViewModel.SchoolId;
                lesson.Url = url;
                
                lesson.LessonCategories = lessonEditViewModel.SelectedCategoryIds.Select(sc => new LessonCategory
                {
                    LessonId = lesson.Id,
                    CategoryId = sc
                }).ToList();
                lesson.ImageUrl = lessonEditViewModel.ImageFile == null ? lessonEditViewModel.ImageUrl : Jobs.UploadImage(lessonEditViewModel.ImageFile, url, "lesson");
                _lessonManager.UpdateLesson(lesson);
                _notyf.Success("Güncelleme işlemi başarıyla tamamlanmıştır.");
                return RedirectToAction("Index");
            }
            var teacherViewModelList = await GetTeacherSelectList();
            var schoolViewModelList = await GetSchoolSelectList();
            var categoryViewModelList = await GetCategoryList();
            var yearList = GetYearList(1900, DateTime.Now.Year);
            lessonEditViewModel.TeacherList = teacherViewModelList;
            lessonEditViewModel.SchoolList = schoolViewModelList;
            lessonEditViewModel.CategoryList = categoryViewModelList;
            lessonEditViewModel.YearList = yearList;
            return View(lessonEditViewModel);
        }
        public async Task<IActionResult> UpdateIsActive(int id)
        {
            Lesson lesson = await _lessonManager.GetByIdAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }
            lesson.IsActive = !lesson.IsActive;
            lesson.ModifiedDate = DateTime.Now;
            _lessonManager.Update(lesson);
            string isActive = lesson.IsActive ? "Aktif" : "Pasif";
            _notyf.Success($"Ders başarıyla {isActive} duruma getirilmiştir.");
            return RedirectToAction("Index");
        }
        
        // Ders Kalıcı Silme
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Lesson lesson = await _lessonManager.GetLessonByIdAsync(id);
            if (lesson == null) return NotFound();
            LessonDeleteViewModel lessonDeleteViewModel = new LessonDeleteViewModel
            {
                Id = lesson.Id,
                Name = lesson.Name,
                TeacherName = lesson.Teacher.FirstName + " " + lesson.Teacher.LastName,
                SchoolName=lesson.School.Name,
                Price = lesson.Price,
                IsActive = lesson.IsActive,
                IsHome = lesson.IsHome
            };
            return View(lessonDeleteViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> HardDelete(int id)
        {
            Lesson lesson = await _lessonManager.GetByIdAsync(id);
            if (lesson == null) return NotFound();
            _lessonManager.Delete(lesson);
            return RedirectToAction("Index");
        }
        
        // Ders Soft Silme
        public async Task<IActionResult> SoftDelete(int id)
        {
            Lesson lesson = await _lessonManager.GetByIdAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }
            lesson.IsDeleted = !lesson.IsDeleted;
            lesson.ModifiedDate = DateTime.Now;
            _lessonManager.Update(lesson);
            string message = lesson.IsDeleted ? "Kayıt silinmiştir. Geri almak için ilgili bölüme geçiniz." : "Kayıt geri alınmıştır.";
            _notyf.Success(message);
            return lesson.IsDeleted ? RedirectToAction("Index") : RedirectToAction("DeletedIndex");
        }
        
        // Silinmiş Dersleri Listeleme
        public async Task<IActionResult> DeletedIndex()
        {
            List<Lesson> lessons = await _lessonManager.GetAllLessonsWithTeacherAndSchool(true);
            List<LessonViewModel> lessonViewModelList = lessons
                .Select(l => new LessonViewModel
                {
                    Id = l.Id,
                    Name = l.Name,
                    Price = l.Price,
                    ImageUrl = l.ImageUrl,
                    IsActive = l.IsActive,
                    TeacherName = l.Teacher.FirstName + " " + l.Teacher.LastName,
                    SchoolName = l.School.Name
                }).ToList();
            LessonListViewModel model = new LessonListViewModel
            {
                LessonViewModelList = lessonViewModelList,
                SourceAction = "DeletedIndex"
            };
            return View("Index", model);
        }

        

    }
}
