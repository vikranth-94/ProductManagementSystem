using ProductManagementSystem.Models;
using ProductManagementSystem.Repositories;

namespace ProductManagementSystem.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProductDetailsAsync()
        {
            return await _productRepository.GetAllProductDetailsAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetProductByIdAsync(id);
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            return await _productRepository.AddProductAsync(product);
        }

        public async Task UpdateProductAsync(Product product)
        {
            await _productRepository.UpdateProductAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteProductAsync(id);
        }

        public async Task DecrementStockAsync(int id, int amount)
        {
            await _productRepository.DecrementStockAsync(id, amount);
        }

        public async Task AddToStockAsync(int id, int amount)
        {
            await _productRepository.AddToStockAsync(id, amount);
        }
    }
}
