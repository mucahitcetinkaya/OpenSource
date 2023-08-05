using LessonWorld.Business.Abstract;
using LessonWorld.Entity.Concrete;
using LessonWorld.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace LessonWorld.Mvc.Controllers
{
    public class LessonsController : Controller
    {
        private readonly ILessonService _lessonManager;
        private readonly ITeacherService _teacherManager;


        public LessonsController(ILessonService lessonManager, ITeacherService teacherManager)
        {
            _lessonManager = lessonManager;
            _teacherManager = teacherManager;
            
        }

        public async Task<IActionResult> LessonList(string categoryUrl = null, string teacherUrl = null, string schoolUrl = null)
        {
            List<Lesson> lessonList = await _lessonManager.GetAllActiveLessonsAsync(categoryUrl, teacherUrl, schoolUrl);
            List<LessonViewModel> lessonViewModelList = lessonList.Select(l => new LessonViewModel
            {
                Id = l.Id,
                Name = l.Name,
                Price = l.Price,
                Url = l.Url,
                ImageUrl = l.ImageUrl,
                TeacherName = l.Teacher.FirstName + " " + l.Teacher.LastName,
                TeacherUrl = l.Teacher.Url,
                SchoolName = l.School.Name,
                SchoolUrl = l.School.Url
            }).ToList();
            return View(lessonViewModelList);
        }
        public async Task<IActionResult> LessonDetails(string url)
        {
            Lesson lesson = await _lessonManager.GetLessonByUrlAsync(url);
            LessonDetailsViewModel lessonDetailsViewModel = new LessonDetailsViewModel
            {
                Id = lesson.Id,
                Name = lesson.Name,
                TeacherName = lesson.Teacher.FirstName + " " + lesson.Teacher.LastName,
                TeacherAbout = lesson.Teacher.About,
                TeacherUrl = lesson.Teacher.Url,
                Url = lesson.Url,
                ImageUrl = lesson.ImageUrl,
                Description = lesson.Description,
                Price = lesson.Price,
                SchoolName = lesson.School.Name,
                SchoolUrl = lesson.School.Url,
                Categories = lesson.LessonCategories.Select(lc => new CategoryViewModel
                {
                    Name = lc.Category.Name,
                    Url = lc.Category.Url
                }).ToList()
            };
            return View(lessonDetailsViewModel);
        }

        public async Task<IActionResult> TeacherList(string categoryUrl = null, string lessonUrl = null, string schoolUrl = null)
        {
            List<Teacher> teacherList = await _teacherManager.GetAllActiveTeachersAsync(categoryUrl, lessonUrl, schoolUrl);
            List<TeacherViewModel> teacherViewModelList = teacherList.Select(t => new TeacherViewModel
            {
                Id = t.Id,
                Name = t.FirstName+ " " + t.LastName,
                BirthOfYear=t.BirthOfYear,
                Url=t.Url,
                Price = t.Price,
                About = t.About,
                PhotoUrl=t.PhotoUrl,
                LessonName=t.Lesson.Name,
                SchoolName=t.School.Name,
                SchoolUrl=t.School.Url,

            }).ToList();
            return View(teacherViewModelList);
        }
        public async Task<IActionResult> TeacherDetails(string url)
        {
            Teacher teacher = await _teacherManager.GetTeacherByUrlAsync(url);
            TeacherDetailsViewModel teacherDetailsViewModel = new TeacherDetailsViewModel
            {
                Id = teacher.Id,
                Name = teacher.FirstName+" "+teacher.LastName,
                LessonName=teacher.Lesson.Name,
                PhotoUrl=teacher.PhotoUrl,
                Price = teacher.Price,
                LessonAbout = teacher.Lesson.About,
                LessonUrl = teacher.Lesson.Url,
                Url = teacher.Url,
                SchoolName = teacher.School.Name,
                SchoolUrl = teacher.School.Url,
                Categories = teacher.TeacherCategories.Select(tc => new CategoryViewModel
                {
                    Name = tc.Category.Name,
                    Url = tc.Category.Url
                }).ToList()
            };
            return View(teacherDetailsViewModel);
        }
    }
}
