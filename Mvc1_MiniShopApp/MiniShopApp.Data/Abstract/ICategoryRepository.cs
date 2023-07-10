using MiniShopApp.Entity.Concrete;

namespace MiniShopApp.Data.Abstract
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<List<Category>> GetCategoriesByProductAsync(int productId);
        Task<List<Category>> GetActiveCategoriesAsync();
    }
}
