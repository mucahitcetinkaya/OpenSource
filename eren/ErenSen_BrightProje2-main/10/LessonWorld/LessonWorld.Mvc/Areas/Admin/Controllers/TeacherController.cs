using AspNetCoreHero.ToastNotification.Abstractions;
using LessonWorld.Business.Abstract;
using LessonWorld.Business.Concrete;
using LessonWorld.Core;
using LessonWorld.Entity.Concrete;
using LessonWorld.Mvc.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LessonWorld.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherManager;
        private readonly ILessonService _lessonManager;
        private readonly INotyfService _notyf;

        public TeacherController(ITeacherService teacherManager, INotyfService notyf, ILessonService lessonManager)
        {
            _teacherManager = teacherManager;
            _notyf = notyf;
            _lessonManager = lessonManager;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Teacher> teacherList = await _teacherManager.GetAllTeachersAsync(false);
            List<TeacherViewModel> teacherViewModelList = teacherList
                .Select(t => new TeacherViewModel
                {
                    Id = t.Id,
                    Name = t.FirstName + " " + t.LastName,
                    CreatedDate = t.CreatedDate,
                    ModifiedDate = t.ModifiedDate,
                    About = t.About,
                    IsActive = t.IsActive,
                    IsAlive = t.IsAlive,
                    Url = t.Url,
                    PhotoUrl = t.PhotoUrl,
                    BirthOfYear = t.BirthOfYear
                }).ToList();
            TeacherListViewModel model = new TeacherListViewModel
            {
                TeacherViewModelList = teacherViewModelList,
                SourceAction = "Index"
            };
            return View(model);
        }
        
         
        [HttpGet]
        public IActionResult Create()
        {
            List<int> years = Jobs.GetYears(0, 2005);
            TeacherAddViewModel teacherAddViewModel = new TeacherAddViewModel
            {
                Years = years.Select(y => new SelectListItem
                {
                    Text = y.ToString(),
                    Value = y.ToString()
                }).ToList()
            };
            return View(teacherAddViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeacherAddViewModel teacherAddViewModel)
        {
            if (ModelState.IsValid)
            {
                string name = teacherAddViewModel.FirstName + " " + teacherAddViewModel.LastName;
                Teacher teacher = new Teacher
                {
                    FirstName = teacherAddViewModel.FirstName,
                    LastName = teacherAddViewModel.LastName,
                    About = teacherAddViewModel.About,
                    IsActive = teacherAddViewModel.IsActive,
                    IsAlive = teacherAddViewModel.IsAlive,
                    BirthOfYear = teacherAddViewModel.BirthOfYear,
                    Url = Jobs.GetUrl(name),
                    PhotoUrl = "default-profile.jpg"

                };
                await _teacherManager.CreateWithUrl(teacher);
                _notyf.Success("Öğretmen kaydı başarıyla tamamlanmıştır.");
                return RedirectToAction("Index");
            }
            List<int> years = Jobs.GetYears(0,2005);
            teacherAddViewModel.Years = years.Select(y => new SelectListItem
            {
                Text = y.ToString(),
                Value = y.ToString()
            }).ToList();
            return View(teacherAddViewModel);
        }

       
        //Öğretmen Güncelleme
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Teacher teacher = await _teacherManager.GetByIdAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            var years = Jobs.GetYears(0, 2005);
            TeacherEditViewModel teacherEditViewModel = new TeacherEditViewModel
            {
                Id = teacher.Id,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                About = teacher.About,
                BirthOfYear = teacher.BirthOfYear,
                IsAlive = teacher.IsAlive,
                IsActive = teacher.IsActive,
                IsDeleted = teacher.IsDeleted,
                Url = teacher.Url,
                PhotoUrl= teacher.PhotoUrl,
                Years = years.Select(y => new SelectListItem
                {
                    Text = y.ToString(),
                    Value = y.ToString(),
                    Selected = teacher.BirthOfYear == y ? true : false
                }).ToList()
            };

            return View(teacherEditViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(TeacherEditViewModel teacherEditViewModel)
        {
            if (ModelState.IsValid)
            {
                Teacher teacher = await _teacherManager.GetByIdAsync(teacherEditViewModel.Id);
                if (teacher == null) { return NotFound(); }
                string photoUrl="";
                string url = Jobs.GetUrl(teacherEditViewModel.FirstName + "-" + teacherEditViewModel.LastName);
                if (teacherEditViewModel.PhotoFile==null)
                {
                    photoUrl = teacher.PhotoUrl;
                }
                else
                {
                    photoUrl = Jobs.UploadImage(teacherEditViewModel.PhotoFile, url, "teacher");
                }
                teacher.FirstName = teacherEditViewModel.FirstName;
                teacher.LastName = teacherEditViewModel.LastName;
                teacher.About = teacherEditViewModel.About;
                teacher.BirthOfYear = teacherEditViewModel.BirthOfYear;
                teacher.IsActive = teacherEditViewModel.IsActive;
                teacher.IsDeleted = teacherEditViewModel.IsDeleted;
                teacher.IsAlive = teacherEditViewModel.IsAlive;
                teacherEditViewModel.Url = url;
                teacher.Url = teacherEditViewModel.Url;
                teacher.PhotoUrl = photoUrl;
                teacher.ModifiedDate = DateTime.Now;
                _teacherManager.Update(teacher);
                _notyf.Success("Öğretmen bilgisi başarıyla güncellenmiştir.", 2);
                return RedirectToAction("Index");
            }
            List<int> years = Jobs.GetYears(0, 2005);
            teacherEditViewModel.Years = years.Select(y => new SelectListItem
            {
                Text = y.ToString(),
                Value = y.ToString(),
                Selected = teacherEditViewModel.BirthOfYear == y ? true : false
            }).ToList();
            return View(teacherEditViewModel);
        }
        public async Task<IActionResult> UpdateIsActive(int id)
        {
            Teacher teacher = await _teacherManager.GetByIdAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            teacher.IsActive = !teacher.IsActive;
            teacher.ModifiedDate = DateTime.Now;
            _teacherManager.Update(teacher);
            string isActive = teacher.IsActive ? "Aktif" : "Pasif";
            _notyf.Success($"Öğretmen başarıyla {isActive} duruma getirilmiştir.");
            return RedirectToAction("Index");
        }
        
        // öğretmen Kalıcı Olarak Silme
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Teacher teacher = await _teacherManager.GetByIdAsync(id);
            if (teacher == null) return NotFound();
            TeacherDeleteViewModel teacherDeleteViewModel = new TeacherDeleteViewModel
            {
                Id = teacher.Id,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                About = teacher.About,
                Url = teacher.Url,
                IsActive = teacher.IsActive,
                IsDeleted = teacher.IsDeleted,
                IsAlive = teacher.IsDeleted,
                CreatedDate = teacher.CreatedDate,
                ModifiedDate = teacher.ModifiedDate
            };
            return View(teacherDeleteViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> HardDelete(int id)
        {
            Teacher teacher = await _teacherManager.GetByIdAsync(id);
            if (teacher == null) return NotFound();
            _teacherManager.Delete(teacher);
            await _lessonManager.UpdateTeacherOfLessons();
            return RedirectToAction("Index");
        }
        
        //Öğretmen silme
        public async Task<IActionResult> SoftDelete(int id)
        {
            Teacher teacher = await _teacherManager.GetByIdAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            teacher.IsDeleted = !teacher.IsDeleted;
            teacher.ModifiedDate = DateTime.Now;
            _teacherManager.Update(teacher);
            string message = teacher.IsDeleted ? "Kayıt silinmiştir. Geri almak için ilgili bölüme geçiniz." : "Kayıt geri alınmıştır.";
            _notyf.Success(message);
            return teacher.IsDeleted ? RedirectToAction("Index") : RedirectToAction("DeletedIndex");
        }
        
        //Silinmiş Öğretmenler listele
        [HttpGet]
        public async Task<IActionResult> DeletedIndex()
        {
            List<Teacher> teacherList = await _teacherManager.GetAllTeachersAsync(true);
            List<TeacherViewModel> teacherViewModelList = teacherList
                .Select(t => new TeacherViewModel
                {
                    Id = t.Id,
                    Name = t.FirstName + " " + t.LastName,
                    CreatedDate = t.CreatedDate,
                    ModifiedDate = t.ModifiedDate,
                    About = t.About,
                    IsActive = t.IsActive,
                    IsAlive = t.IsAlive,
                    Url = t.Url,
                    PhotoUrl = t.PhotoUrl,
                    BirthOfYear = t.BirthOfYear
                }).ToList();
            TeacherListViewModel model = new TeacherListViewModel
            {
                TeacherViewModelList = teacherViewModelList,
                SourceAction = "DeletedIndex"
            };
            return View("Index",model);
        }
        

    }
}
