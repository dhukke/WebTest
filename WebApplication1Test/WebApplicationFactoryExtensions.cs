using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using WebApplication1;
using WebApplication1.Data;

namespace WebApplication1Test.IntegrationTests.Pages
{
    public static class WebApplicationFactoryExtensions
    {
        public static HttpClient CreateClientWithMemberAndDbSetup(this WebApplicationFactory<Startup> factory,
            Action<TestsDbContext> configure)
        {
            var client = factory.WithWebHostBuilder(builder =>
            {
                builder.WithMemberUser().ConfigureTestDatabase(configure);
            }).CreateClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Test");

            return client;
        }
    }
}

