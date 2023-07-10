using MiniShopApp.Business.Abstract;
using MiniShopApp.Data.Abstract;
using MiniShopApp.Entity.Concrete;

namespace MiniShopApp.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task CreateAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetActiveProductsAsync(string categoryUrl=null)
        {
            return await _productRepository.GetActiveProductsAsync(categoryUrl);
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task<List<Product>> GetHomePageProductsAsync()
        {
            return await _productRepository.GetHomePageProductsAsync();
        }

        public async Task<Product> GetProductByUrlAsync(string url)
        {
            return await _productRepository.GetProductByUrlAsync(url);
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
