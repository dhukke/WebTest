using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using WebApplication1.Data;
using WebApplication1.IntegrationTests.Pages;
using WebApplication1Test.IntegrationTests.Helpers;

namespace WebApplication1Test.IntegrationTests.Pages
{
    public static class WebHostBuilderExtensions
    {
        public static IWebHostBuilder WithMemberUser(this IWebHostBuilder builder)
        {
            return builder.ConfigureTestServices(services =>
            {
                services.AddAuthentication("Test")
                    .AddScheme<TestAuthenticationSchemeOptions, TestAuthenticationHandler>(
                        "Test", options => options.Role = "Member");
            });
        }

        public static IWebHostBuilder ConfigureTestDatabase(this IWebHostBuilder builder, Action<TestsDbContext> configure)
        {
            return builder.ConfigureTestServices(services =>
            {
                var sp = services.BuildServiceProvider();
                using var scope = sp.CreateScope();
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<TestsDbContext>();
                var logger = scopedServices.GetRequiredService<ILogger<ProductsGetTests>>();

                try
                {
                    configure(db);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred setting up the " +
                                        "database for the test. Error: {Message}", ex.Message);
                }
            });
        }
    }
}

