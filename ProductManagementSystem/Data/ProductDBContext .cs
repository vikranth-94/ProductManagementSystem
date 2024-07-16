using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ProductManagementSystem.Models;

namespace ProductManagementSystem.Data
{
    public class ProductDBContext : DbContext
    {
        public ProductDBContext(DbContextOptions<ProductDBContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
           .Property(p => p.Id)
           .ValueGeneratedNever();
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
          .HasIndex(e => e.Username)
        .IsUnique();
        }
      
    }
}