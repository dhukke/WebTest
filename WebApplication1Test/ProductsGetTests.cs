
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net;
using System.Threading.Tasks;
using WebApplication1.Entities;
using WebApplication1Test.IntegrationTests.Helpers;
using WebApplication1Test.IntegrationTests.Pages;
using Xunit;

namespace WebApplication1.IntegrationTests.Pages
{
    public class ProductsGetTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public ProductsGetTests(CustomWebApplicationFactory<Startup> factory)
        {
            factory.ClientOptions.BaseAddress = new Uri("http://localhost/api/test");
            _factory = factory;
        }

        [Fact]
        public async Task Get_WhenHasProduct()
        {
            var guid = Guid.NewGuid();
            var client = _factory.CreateClientWithMemberAndDbSetup(db =>
            {
                DatabaseHelper.ResetDbForTests(db);

                db.Products.Add(new Product
                {
                    Id = guid,
                    Name = "Bla"
                });

                db.SaveChanges();
            });

            var response = await client.GetAsync($"?id= {guid}");


            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
