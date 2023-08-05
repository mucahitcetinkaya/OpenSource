using LessonWorld.Business.Abstract;
using LessonWorld.Entity.Concrete;
using LessonWorld.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace LessonWorld.Mvc.Controllers
{
    public class LessonsController : Controller
    {
        private readonly ILessonService _lessonManager;

        public LessonsController(ILessonService lessonManager)
        {
            _lessonManager = lessonManager;
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
    }
}
