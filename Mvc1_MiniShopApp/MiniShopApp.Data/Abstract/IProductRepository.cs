using MiniShopApp.Entity.Concrete;

namespace MiniShopApp.Data.Abstract
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetHomePageProductsAsync();
        Task<List<Product>> GetActiveProductsAsync(string categoryUrl);
        Task<Product> GetProductByUrlAsync(string url);
    }
}
