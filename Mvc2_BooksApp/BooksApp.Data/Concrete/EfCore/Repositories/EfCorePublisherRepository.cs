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
    public class EfCorePublisherRepository : EfCoreGenericRepository<Publisher>, IPublisherRepository
    {
        public EfCorePublisherRepository(BooksAppContext _context):base(_context)
        {
            
        }
        BooksAppContext Context
        {
            get { return _dbContext as BooksAppContext; }
        }
        public async Task<List<Publisher>> GetAllPublishersAsync(bool isDeleted, bool? isActive = null)
        {
            var result = Context
                .Publishers
                .Where(a => a.IsDeleted == isDeleted)
                .AsQueryable();
            if (isActive != null)
            {
                result = result
                    .Where(a => a.IsActive == isActive)
                    .AsQueryable();
            }
            return await result.ToListAsync();
        }
    }
}
