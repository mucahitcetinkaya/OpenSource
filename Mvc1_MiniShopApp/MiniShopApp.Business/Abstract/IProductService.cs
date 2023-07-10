using MiniShopApp.Entity.Concrete;

namespace MiniShopApp.Business.Abstract
{
    public interface IProductService
    {
        #region Generic
        Task<Product> GetByIdAsync(int id);
        Task<List<Product>> GetAllAsync();
        Task CreateAsync(Product product);
        void Update(Product product);
        void Delete(Product product);
        #endregion

        #region Special
        Task<List<Product>> GetHomePageProductsAsync();
        Task<List<Product>> GetActiveProductsAsync(string categoryUrl=null);
        Task<Product> GetProductByUrlAsync(string url);
        #endregion
    }
}
