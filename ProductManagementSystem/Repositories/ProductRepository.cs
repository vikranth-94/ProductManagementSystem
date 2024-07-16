using Microsoft.EntityFrameworkCore;
using ProductManagementSystem.Data;
using ProductManagementSystem.Models;

namespace ProductManagementSystem.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDBContext _context;

        public ProductRepository(ProductDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProductDetailsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            product.Id = GenerateId(); // Generating 6 digit Product Id
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }
        private int GenerateId()
        {
            int Id = _context.Products.Any() ? _context.Products.Max(p => p.Id) + 1 : 100000; 
            return Id;
        }
        public async Task UpdateProductAsync(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DecrementStockAsync(int id, int amount)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                product.AvailableStock -= amount;
                _context.Entry(product).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddToStockAsync(int id, int amount)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                product.AvailableStock += amount;
                _context.Entry(product).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }
}