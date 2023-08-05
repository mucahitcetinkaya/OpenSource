using LessonWorld.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonWorld.Business.Abstract
{
    public interface ILessonService
    {
        Task<Lesson> GetByIdAsync(int? id);
        Task<List<Lesson>> GetAllAsync();
        Task CreateAsync(Lesson lesson);
        void Update(Lesson lesson);
        void Delete(Lesson lesson);


        Task<List<Lesson>> GetLessonsWithFullDataAsync(bool? isHome = null, bool? isActive = null);
        Task<List<Lesson>> GetAllActiveLessonsAsync(string categoryUrl = null, string teacherUrl = null, string schoolUrl = null);
        Task<Lesson> GetLessonByUrlAsync(string lessonUrl);
        Task<Lesson> GetLessonByIdAsync(int id);
        Task<List<Lesson>> GetAllLessonsWithTeacherAndSchool(bool isDeleted);
        Task CreateLessonAsync(Lesson lesson, List<int> SelectedCategoryIds);
        Task UpdateTeacherOfLessons();
        Task UpdateSchoolOfLessons();
        Task CheckLessonsCategories();
        void UpdateLesson(Lesson lesson);
    }
}
