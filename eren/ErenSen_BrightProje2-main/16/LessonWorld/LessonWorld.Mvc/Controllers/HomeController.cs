using LessonWorld.Business.Abstract;
using LessonWorld.Entity.Concrete;
using LessonWorld.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LessonWorld.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILessonService _lessonManager;

        public HomeController(ILessonService lessonManager)
        {
            _lessonManager = lessonManager;
        }

        public async Task<IActionResult> Index()
        {
            List<Lesson> lessonList = await _lessonManager.GetLessonsWithFullDataAsync(true, true);

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
       
    }
}