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

    }
}
