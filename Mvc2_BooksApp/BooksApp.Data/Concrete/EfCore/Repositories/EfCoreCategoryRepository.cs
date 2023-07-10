using BooksApp.Data.Abstract;
using BooksApp.Data.Concrete.EfCore.Contexts;
using BooksApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.Data.Concrete.EfCore.Repositories
{
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category>, ICategoryRepository
    {
        public EfCoreCategoryRepository(BooksAppContext _context): base(_context)
        {
            
        }
        private BooksAppContext Context
        {
            get { return _dbContext as BooksAppContext; }
        }
        public async Task<List<Category>> GetAllCategoriesAsync(bool isDeleted, bool? isActive=null)
        {
            var result = Context
                .Categories
                .Where(c => c.IsDeleted == isDeleted)
                .AsQueryable();
            if (isActive!=null)
            {
                result = result
                    .Where(c => c.IsActive == isActive)
                    .AsQueryable();
            }
            return await result.ToListAsync();
        }
    }
}
