using Microsoft.EntityFrameworkCore;
using System;
using WebApplication1.Entities;

namespace WebApplication1.Data
{
    public class TestsDbContext : DbContext
    {
        public TestsDbContext(DbContextOptions<TestsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = Guid.NewGuid(), Name = "Court 1" },
                new Product { Id = Guid.NewGuid(), Name = "Court 2" },
                new Product { Id = Guid.NewGuid(), Name = "Court 3" },
                new Product { Id = Guid.NewGuid(), Name = "Court 4" },
                new Product { Id = Guid.NewGuid(), Name = "Court 5" });

            base.OnModelCreating(modelBuilder);
        }
    }
}
