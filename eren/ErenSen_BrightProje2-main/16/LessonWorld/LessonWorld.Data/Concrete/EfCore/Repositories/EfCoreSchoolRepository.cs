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
    public class EfCoreSchoolRepository : EfCoreGenericRepository<School>, ISchoolRepository
    {
        public EfCoreSchoolRepository(LessonWorldContext _context) : base(_context)
        {

        }
        LessonWorldContext Context
        {
            get { return _dbContext as LessonWorldContext; }
        }
        public async Task<List<School>> GetAllSchoolsAsync(bool isDeleted, bool? isActive = null)
        {
            var result = Context
                 .Schools
                 .Where(t => t.IsDeleted == isDeleted)
                 .AsQueryable();
            if (isActive != null)
            {
                result = result.Where(t => t.IsActive == isActive).AsQueryable();
            }
            return await result.ToListAsync();
        }
    }
}
