using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductId);
            builder.Property(p => p.ProductName).IsRequired();
            builder.Property(p => p.Price).IsRequired();

            builder.HasData(
                new Product() { ProductId = 1, CategoryId = 2, ProductName = "Computer", Price = 17_000, ImageUrl = "/images/1.jpg", ShowCase = false },
                new Product() { ProductId = 2, CategoryId = 2, ProductName = "Keyboard", Price = 1_000, ImageUrl = "/images/2.jpg", ShowCase = false },
                new Product() { ProductId = 3, CategoryId = 2, ProductName = "Mouse", Price = 5000, ImageUrl = "/images/3.jpg", ShowCase = false },
                new Product() { ProductId = 4, CategoryId = 2, ProductName = "Monitor", Price = 7_000, ImageUrl = "/images/4.jpg", ShowCase = false },
                new Product() { ProductId = 5, CategoryId = 2, ProductName = "Deck", Price = 1_500, ImageUrl = "/images/5.jpg", ShowCase = false },
                new Product() { ProductId = 6, CategoryId = 1, ProductName = "History", Price = 25, ImageUrl = "/images/6.jpg", ShowCase = false },
                new Product() { ProductId = 7, CategoryId = 1, ProductName = "Hamlet", Price = 45, ImageUrl = "/images/7.jpg", ShowCase = false },
                new Product() { ProductId = 8, CategoryId = 1, ProductName = "Xp-Pen", Price = 1145, ImageUrl = "/images/8.jpg", ShowCase = true },
                new Product() { ProductId = 9, CategoryId = 2, ProductName = "Galaxy FE", Price = 4445, ImageUrl = "/images/9.jpg", ShowCase = true },
                new Product() { ProductId = 10, CategoryId = 1, ProductName = "HP Mouse", Price = 545, ImageUrl = "/images/10.jpg", ShowCase = true }
            );
        }
    }
}