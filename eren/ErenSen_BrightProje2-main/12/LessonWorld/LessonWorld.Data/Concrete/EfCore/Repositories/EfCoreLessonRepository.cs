using LessonWorld.Data.Abstract;
using LessonWorld.Data.Concrete.EfCore.Contexts;
using LessonWorld.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonWorld.Data.Concrete.EfCore.Repositories
{
    public class EfCoreLessonRepository : EfCoreGenericRepository<Lesson>, ILessonRepository
    {
        public EfCoreLessonRepository(LessonWorldContext _context) : base(_context)
        {

        }

        private LessonWorldContext Context
        {
            get { return _dbContext as LessonWorldContext; }
        }

        public async Task CheckLessonsCategories()
        {
            var lessonCategoryIds = await Context
                .LessonCategories
                .Select(lc => lc.LessonId)
                .Distinct()
                .ToListAsync();
            var lessonIds = await Context
                .Lessons
                .Select(l => l.Id)
                .ToListAsync();
            List<int> different = lessonIds.Except(lessonCategoryIds).ToList();

            await Context.LessonCategories.AddRangeAsync(different.Select(d => new LessonCategory
            {
                LessonId = d,
                CategoryId = 1
            }).ToList());
            await Context.SaveChangesAsync();
        }

        public async Task CreateLessonAsync(Lesson lesson, List<int> SelectedCategoryIds)
        {
            await Context.Lessons.AddAsync(lesson);
            await Context.SaveChangesAsync();
            lesson.LessonCategories = SelectedCategoryIds.Select(sc => new LessonCategory
            {
                LessonId = lesson.Id,
                CategoryId = sc
            }).ToList();
            Context.Lessons.Update(lesson);
            await Context.SaveChangesAsync();



        }

        public async Task<List<Lesson>> GetAllActiveLessonsAsync(string categoryUrl = null, string teacherUrl = null, string schoolUrl = null)
        {

            var result = Context
                .Lessons
                .Where(l => l.IsActive && !l.IsDeleted)
                .Include(l => l.Teacher)
                .Include(l => l.School)
                .AsQueryable();
            if (categoryUrl != null)
            {
                result = result
                    .Include(l => l.LessonCategories)
                    .ThenInclude(lc => lc.Category)
                    .Where(l => l.LessonCategories.Any(lc => lc.Category.Url == categoryUrl))
                    .AsQueryable();
            }
            if (teacherUrl != null)
            {
                result = result
                    .Where(l => l.Teacher.Url == teacherUrl)
                    .AsQueryable();
            }
            if (schoolUrl != null)
            {
                result = result
                    .Where(l => l.School.Url == schoolUrl)
                    .AsQueryable();
            }
            return await result.ToListAsync();
        }

        public async Task<List<Lesson>> GetAllLessonsWithTeacherAndSchool(bool isDeleted)
        {
            var result = await Context
                .Lessons
                .Where(l => l.IsDeleted == isDeleted)
                .Include(l => l.Teacher)
                .Include(l => l.School)
                .ToListAsync();
            return result;
        }

        public async Task<Lesson> GetLessonByIdAsync(int id)
        {
            var result = await Context
                .Lessons
                .Where(l => l.IsActive && !l.IsDeleted && l.Id == id)
                .Include(l => l.LessonCategories)
                .ThenInclude(lc => lc.Category)
                .Include(l => l.Teacher)
                .Include(l => l.School)
                .FirstOrDefaultAsync();
            return result;
        }

        public async Task<Lesson> GetLessonByUrlAsync(string lessonUrl)
        {
            var result = await Context
                .Lessons
                .Where(l => l.IsActive && !l.IsDeleted && l.Url == lessonUrl)
                .Include(l => l.LessonCategories)
                .ThenInclude(lc => lc.Category)
                .Include(l => l.Teacher)
                .Include(l => l.School)
                .FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<Lesson>> GetLessonsWithFullDataAsync(bool? isHome = null, bool? isActive = null)
        {
            var result = Context
                .Lessons
                .Where(l => !l.IsDeleted)
                .AsQueryable();

            if (isHome != null)
            {
                result = result
                    .Where(l => l.IsHome == isHome)
                    .AsQueryable();
            }

            if (isActive != null)
            {
                result = result
                    .Where(l => l.IsActive == isActive)
                    .AsQueryable();
            }
            result = result
                .Include(l => l.LessonCategories)
                .ThenInclude(lc => lc.Category)
                .Include(l => l.Teacher)
                .Include(l => l.School)
                .AsQueryable();

            return await result.ToListAsync();
        }

        public async Task UpdateTeacherOfLessons()
        {
            var lessons = await Context
                .Lessons
                .Where(l => l.TeacherId == null)
                .ToListAsync();
            foreach (var lesson in lessons)
            {
                lesson.TeacherId = 1;
            };
            Context.Lessons.UpdateRange(lessons);
            await Context.SaveChangesAsync();
        }

        public void UpdateLesson(Lesson lesson)
        {
            Lesson oldLesson = Context
                .Lessons
                .Include(l => l.LessonCategories)
                .ThenInclude(lc => lc.Category)
                .Include(l => l.Teacher)
                .Include(l => l.School)
                .Where(l => l.Id == lesson.Id)
                .FirstOrDefault();
            oldLesson.Name = lesson.Name;
            oldLesson.Description = lesson.Description;
            oldLesson.Price = lesson.Price;
            oldLesson.IsActive = lesson.IsActive;
            oldLesson.IsHome = lesson.IsHome;
            oldLesson.IsDeleted = lesson.IsDeleted;
            oldLesson.TeacherId = lesson.TeacherId;
            oldLesson.SchoolId = lesson.SchoolId;
            oldLesson.Url = lesson.Url;
            oldLesson.ModifiedDate = DateTime.Now;
            oldLesson.LessonCategories = lesson.LessonCategories;
            oldLesson.ImageUrl = lesson.ImageUrl;

            Context.Lessons.Update(oldLesson);
            Context.SaveChanges();
        }

        public async Task UpdateSchoolOfLessons()
        {
            var lessons = await Context
                .Lessons
                .Where(l => l.SchoolId == null)
                .ToListAsync();
            foreach (var lesson in lessons)
            {
                lesson.SchoolId = 1;
            };
            Context.Lessons.UpdateRange(lessons);
            await Context.SaveChangesAsync();
        }

    }
}

