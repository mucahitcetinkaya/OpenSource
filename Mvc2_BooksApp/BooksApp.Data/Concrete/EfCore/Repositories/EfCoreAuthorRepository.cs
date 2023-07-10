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
    public class EfCoreAuthorRepository : EfCoreGenericRepository<Author>, IAuthorRepository
    {
        public EfCoreAuthorRepository(BooksAppContext _context) : base(_context)
        {

        }

        private BooksAppContext Context
        {
            get { return _dbContext as BooksAppContext; }
        }

        public async Task CreateWithUrl(Author author)
        {
            await Context.Authors.AddAsync(author);
            await Context.SaveChangesAsync();
            author.Url = author.Url + "-" + author.Id;
            await Context.SaveChangesAsync();
        }

        public async Task<List<Author>> GetAllAuthorsAsync(bool isDeleted, bool? isActive = null)
        {
            var result = Context
                .Authors
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
