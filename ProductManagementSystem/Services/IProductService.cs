﻿using ProductManagementSystem.Models;

namespace ProductManagementSystem.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductDetailsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
        Task DecrementStockAsync(int id, int amount);
        Task AddToStockAsync(int id, int amount);
    }
}
