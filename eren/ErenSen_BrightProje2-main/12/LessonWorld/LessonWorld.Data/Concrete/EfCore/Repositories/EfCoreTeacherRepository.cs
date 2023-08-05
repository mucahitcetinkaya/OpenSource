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
    public class EfCoreTeacherRepository : EfCoreGenericRepository<Teacher>, ITeacherRepository
    {
        

        public EfCoreTeacherRepository(LessonWorldContext _context) : base(_context)
        {

        }
        private LessonWorldContext Context
        {
            get { return _dbContext as LessonWorldContext; }
        }
        public async Task CreateWithUrl(Teacher teacher)
        {
            await Context.Teachers.AddAsync(teacher);
            await Context.SaveChangesAsync();
            teacher.Url = teacher.Url + "-" + teacher.Id;
            await Context.SaveChangesAsync();
        }

        public async Task<List<Teacher>> GetAllTeachersAsync(bool isDeleted, bool? isActive = null)
        {
            var result = Context
               .Teachers
               .Where(t => t.IsDeleted == isDeleted)
               .AsQueryable();
            if (isActive != null)
            {
                result = result
                    .Where(t => t.IsActive == isActive)
                    .AsQueryable();
            }
            return await result.ToListAsync();
        }

        public async Task<List<Teacher>> GetAllActiveTeachersAsync(string categoryUrl = null, string lessonUrl = null, string schoolUrl = null)
        {

            var result = Context
                .Teachers
                .Where(t => t.IsActive && !t.IsDeleted)
                .Include(t => t.Lesson)
                .Include(t => t.School)
                .AsQueryable();
            if (categoryUrl != null)
            {
                result = result
                    .Include(t => t.TeacherCategories)
                    .ThenInclude(tc => tc.Category)
                    .Where(t => t.TeacherCategories.Any(tc => tc.Category.Url == categoryUrl))
                    .AsQueryable();
            }
            if (lessonUrl != null)
            {
                result = result
                    .Where(t => t.Lesson.Url == lessonUrl)
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

        public async Task<Teacher> GetTeacherByUrlAsync(string teacherUrl)
        {
            var result = await Context
                .Teachers
                .Where(t => t.IsActive && !t.IsDeleted && t.Url == teacherUrl)
                .Include(t => t.TeacherCategories)
                .ThenInclude(tc => tc.Category)
                .Include(t => t.Lesson)
                .Include(t => t.School)
                .FirstOrDefaultAsync();
            return result;
        }

        
    }
}
