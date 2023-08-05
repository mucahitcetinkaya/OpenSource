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
            TeacherListViewModel teacherListViewModel = new TeacherListViewModel();
            if (RouteData.Values["teacherurl"] != null)
            {
                teacherListViewModel.SelectedTeacherUrl = RouteData.Values["teacherurl"].ToString();
            }
            else
            {
                teacherListViewModel.SelectedTeacherUrl = "";
            }

            List<Teacher> teacherList = await _teacherManager.GetAllAsync();
            List<TeacherViewModel> teacherViewModelList = teacherList
                .Select(t => new TeacherViewModel
            {
                Name = t.FirstName + " " + t.LastName,
                Url = t.Url
            }).ToList();

            teacherListViewModel.TeacherViewModelList = teacherViewModelList;

            return View(teacherViewModelList);
        }
    }
}