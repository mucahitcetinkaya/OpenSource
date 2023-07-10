using Microsoft.EntityFrameworkCore;
using MiniShopApp.Data.Abstract;
using MiniShopApp.Data.Concrete.EfCore.Contexts;
using MiniShopApp.Entity.Concrete;

namespace MiniShopApp.Data.Concrete.EfCore.Repositories
{
    public class EfCoreProductRepository : EfCoreGenericRepository<Product>, IProductRepository
    {
        MiniShopAppContext _context = new MiniShopAppContext();

        public async Task<List<Product>> GetActiveProductsAsync(string categoryUrl)
        {
            List<Product> result;
            if (categoryUrl==null)
            {
                result = await _context
                    .Products
                    .Where(p => p.IsActive && !p.IsDeleted)
                    .ToListAsync();
            }
            else
            {
                result = await _context
                    .Products
                    .Where(p => p.IsActive && !p.IsDeleted)
                    .Include(p=>p.ProductCategories)
                    .ThenInclude(pc=>pc.Category)
                    .Where(p=>p.ProductCategories.Any(pc=>pc.Category.Url == categoryUrl))
                    .ToListAsync();                
            }

            return result;
        }

        public async Task<List<Product>> GetHomePageProductsAsync()
        {
            var result = await _context
                .Products
                .Where(p => p.IsActive && !p.IsDeleted && p.IsHome)
                .ToListAsync();
            return result;
        }

        public async Task<Product> GetProductByUrlAsync(string url)
        {
            var result = await _context
                .Products
                .Where(p => p.IsActive && !p.IsDeleted && p.Url == url)
                .Include(p => p.ProductCategories)
                .ThenInclude(pc => pc.Category)
                .FirstOrDefaultAsync();
            return result;
        }
    }
}
