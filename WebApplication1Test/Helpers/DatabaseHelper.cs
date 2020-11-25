using System;
using System.Linq;
using WebApplication1.Data;
using WebApplication1.Entities;

namespace WebApplication1Test.IntegrationTests.Helpers
{
    public static class DatabaseHelper
    {
        public static void InitialiseDbForTests(TestsDbContext dbContext)
        {
            dbContext.Products.Add(new Product
            {
                Id = Guid.NewGuid(),
                Name = "TEST"
            });
            
            dbContext.SaveChanges();
        }

        public static void ResetDbForTests(TestsDbContext dbContext)
        {
            var members = dbContext.Products.ToArray();

            dbContext.Products.RemoveRange(members);

            dbContext.SaveChanges();

            InitialiseDbForTests(dbContext);
        }
    }
}
