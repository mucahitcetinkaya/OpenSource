using LessonWorld.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonWorld.Data.Abstract
{
    public interface ILessonRepository : IGenericRepository<Lesson>
    {
        Task<List<Lesson>> GetAllActiveLessonsAsync(string categoryUrl = null, string teacherUrl = null, string schoolUrl = null);
        Task<Lesson> GetLessonByUrlAsync(string lessonUrl);


        Task<List<Lesson>> GetLessonsWithFullDataAsync(bool? isHome = null, bool? isActive = null);
        Task<Lesson> GetLessonByIdAsync(int id);
        Task<List<Lesson>> GetAllLessonsWithTeacherAndSchool(bool isDeleted);
        Task CreateLessonAsync(Lesson lesson, List<int> SelectedCategoryIds);
        Task UpdateTeacherOfLessons();
        Task UpdateSchoolOfLessons();
        Task CheckLessonsCategories();
        void UpdateLesson(Lesson lesson);

    }
}
