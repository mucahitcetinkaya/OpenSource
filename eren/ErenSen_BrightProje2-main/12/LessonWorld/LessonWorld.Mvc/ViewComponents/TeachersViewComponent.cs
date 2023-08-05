using LessonWorld.Business.Abstract;
using LessonWorld.Entity.Concrete;
using LessonWorld.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace LessonWorld.Mvc.ViewComponents
{
    public class TeachersViewComponent : ViewComponent
    {
        private readonly ITeacherService _teacherManager;

        public TeachersViewComponent(ITeacherService teacherManager)
        {
            _teacherManager = teacherManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Teacher> teacherList = await _teacherManager.GetAllAsync();
            List<TeacherViewModel> teacherViewModelList = teacherList.Select(t => new TeacherViewModel
            {
                Name = t.FirstName + " " + t.LastName,
                Url = t.Url
            }).ToList();
            return View(teacherViewModelList);
        }
    }
}
