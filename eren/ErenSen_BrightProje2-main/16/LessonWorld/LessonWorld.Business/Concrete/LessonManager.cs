using LessonWorld.Business.Abstract;
using LessonWorld.Entity.Concrete;
using LessonWorld.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonWorld.Business.Concrete
{
    public class LessonManager : ILessonService
    {
            private readonly ILessonRepository _lessonRepository;

            public LessonManager(ILessonRepository lessonRepository)
            {
                _lessonRepository = lessonRepository;
            }

            public async Task CreateAsync(Lesson lesson)
            {
                await _lessonRepository.CreateAsync(lesson);
            }

            public void Delete(Lesson lesson)
            {
                _lessonRepository.Delete(lesson);
            }

            public async Task<List<Lesson>> GetAllAsync()
            {
                var result = await _lessonRepository.GetAllAsync();
                return result;
            }

            public async Task<Lesson> GetByIdAsync(int? id)
            {
              var result = await _lessonRepository.GetByIdAsync(id);
               return result;
            }

            public void Update(Lesson lesson)
            {
                _lessonRepository.Update(lesson);
            }

            public async Task<List<Lesson>> GetLessonsWithFullDataAsync(bool? isHome = null, bool? isActive = null)
            {
                var result = await _lessonRepository.GetLessonsWithFullDataAsync(isHome, isActive);
                return result;
            }

            public async Task<List<Lesson>> GetAllActiveLessonsAsync(string categoryUrl = null, string teacherUrl = null, string schoolUrl = null)
            {
                var result = await _lessonRepository.GetAllActiveLessonsAsync(categoryUrl, teacherUrl, schoolUrl);
                return result;
            }

            public async Task<Lesson> GetLessonByUrlAsync(string lessonUrl)
            {
                var result = await _lessonRepository.GetLessonByUrlAsync(lessonUrl);
                return result;
            }

            public async Task<List<Lesson>> GetAllLessonsWithTeacherAndSchool(bool isDeleted)
            {
                var result = await _lessonRepository.GetAllLessonsWithTeacherAndSchool(isDeleted);
                return result;
            }

            public async Task CreateLessonAsync(Lesson lesson, List<int> SelectedCategoryIds)
            {
                await _lessonRepository.CreateLessonAsync(lesson, SelectedCategoryIds);
            }

            public async Task<Lesson> GetLessonByIdAsync(int id)
            {
                return await _lessonRepository.GetLessonByIdAsync(id);
            }

            public async Task UpdateTeacherOfLessons()
            {
                await _lessonRepository.UpdateTeacherOfLessons();
            }

            public async Task UpdateSchoolOfLessons()
            {
                await _lessonRepository.UpdateSchoolOfLessons();
            }

            public async Task CheckLessonsCategories()
            {
                await _lessonRepository.CheckLessonsCategories();
            }

            public void UpdateLesson(Lesson lesson)
            {
                _lessonRepository.UpdateLesson(lesson);
            }

        
    }
}
