using System;
using EFStore.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFStore.Contexts
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            PropertiesConfiguration(modelBuilder);

            SeedingData(modelBuilder);
        }

        public void PropertiesConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                        .HasKey(c => c.Id);

            modelBuilder.Entity<Category>()
                        .Property(c => c.Id)
                        .ValueGeneratedOnAdd();

            modelBuilder.Entity<Product>()
                        .HasKey(p => p.Id);

            modelBuilder.Entity<Product>()
                        .Property(p => p.Id)
                        .ValueGeneratedOnAdd();

            modelBuilder.Entity<ProductCategory>()
                        .HasKey(pc => new { pc.ProductId, pc.CategoryId });

            modelBuilder.Entity<ProductCategory>()
                        .HasOne<Product>(pc => pc.Product)
                        .WithMany(s => s.ProductCategories)
                        .HasForeignKey(pc => pc.ProductId)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductCategory>()
                        .HasOne<Category>(pc => pc.Category)
                        .WithMany(s => s.ProductCategories)
                        .HasForeignKey(pc => pc.CategoryId)
                        .OnDelete(DeleteBehavior.Cascade);
        }

        public void SeedingData(ModelBuilder modelBuilder)
        {
            Guid cId1 = Guid.NewGuid();
            Guid cId2 = Guid.NewGuid();
            Guid cId3 = Guid.NewGuid();
            Guid pId1 = Guid.NewGuid();
            Guid pId2 = Guid.NewGuid();
            Guid pId3 = Guid.NewGuid();

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = cId1, Name = "Cat1" },
                new Category { Id = cId2, Name = "Cat2" },
                new Category { Id = cId3, Name = "Cat3" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = pId1,
                    Name = "Pro1",
                    Manufacture = "M1",
                },
                new Product
                {
                    Id = pId2,
                    Name = "Pro2",
                    Manufacture = "M2",
                },
                new Product
                {
                    Id = pId3,
                    Name = "Pro3",
                    Manufacture = "M3",
                }
            );

            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory
                {
                    ProductId = pId1,
                    CategoryId = cId3
                },
                new ProductCategory
                {
                    ProductId = pId2,
                    CategoryId = cId1
                },
                new ProductCategory
                {
                    ProductId = pId3,
                    CategoryId = cId2
                }
            );
        }
    }
}