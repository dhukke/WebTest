
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1Test.IntegrationTests.Helpers;
using WebApplication1Test.IntegrationTests.Pages;
using Xunit;

namespace WebApplication1.IntegrationTests.Pages
{
    public class ProductsPostTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public ProductsPostTests(CustomWebApplicationFactory<Startup> factory)
        {
            factory.ClientOptions.BaseAddress = new Uri("http://localhost/api/test");
            _factory = factory;
        }

        [Fact]
        public async Task Post_ShouldWork()
        {
            var client = _factory.CreateClientWithMemberAndDbSetup(db =>
            {
                DatabaseHelper.ResetDbForTests(db);
            });

            var payload = new ProductPayload
            {
                Name = "OkOk"
            };

            var result = await client.PostAsJsonAsync("http://localhost/api/test", payload);

            result.StatusCode.Should().Be(HttpStatusCode.OK);

            var context = _factory.Services.GetService<TestsDbContext>();
            var product = context.Products.FirstOrDefault(x => x.Name == "OkOk");

            product.Should().NotBeNull();
        }
    }
}
