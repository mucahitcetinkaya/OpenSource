using Microsoft.EntityFrameworkCore;
using MiniShopApp.Data.Abstract;
using MiniShopApp.Data.Concrete.EfCore.Contexts;
using MiniShopApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniShopApp.Data.Concrete.EfCore.Repositories
{
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category>, ICategoryRepository
    {
        MiniShopAppContext _context = new MiniShopAppContext();
        public async Task<List<Category>> GetActiveCategoriesAsync()
        {
            var result = await _context
                .Categories
                .Where(c => c.IsActive && !c.IsDeleted)
                .ToListAsync();
            return result;
        }

        public async Task<List<Category>> GetCategoriesByProductAsync(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
