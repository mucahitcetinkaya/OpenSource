using LessonWorld.Business.Abstract;
using LessonWorld.Entity.Concrete;
using LessonWorld.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace LessonWorld.Mvc.ViewComponents
{
    public class SchoolsViewComponent:ViewComponent
    {
        private readonly ISchoolService _schoolManager;

        public SchoolsViewComponent(ISchoolService schoolManager)
        {
            _schoolManager = schoolManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<School> schoolList = await _schoolManager.GetAllAsync();
            List<SchoolViewModel> schoolViewModelList = schoolList.Select(s => new SchoolViewModel
            {
                Name=s.Name,
                Url=s.Url
            }).ToList();
            return View(schoolViewModelList);
        }
    }
}
