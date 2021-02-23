using DataManager;
using DataManager.Contracts;
using DataManager.Contracts.V1.DTO.Auth;
using DataManager.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DataManagmentTests.IntegrationTests
{
    public class IntegrationTest : IDisposable
    {
        protected readonly HttpClient testClient;
        private readonly IServiceProvider _serviceProvider;
        private readonly IServiceScope _serviceScope;
        private ApplicationDbContext dbCon;

        public IntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(async services =>
                    {
                        var descriptor = services.SingleOrDefault(
                         d => d.ServiceType ==
                         typeof(DbContextOptions<ApplicationDbContext>));

                        services.Remove(descriptor);

                        services.AddDbContext<ApplicationDbContext>(options =>
                        {
                            options.UseInMemoryDatabase("InMemoryDbForTesting");
                        });

                        var sp = services.BuildServiceProvider();

                        using (var scope = sp.CreateScope())
                        {
                            var scopedServices = scope.ServiceProvider;
                            var db = scopedServices.GetRequiredService<ApplicationDbContext>();


                            db.Database.EnsureCreated();

                        }

                    });

                });
            _serviceProvider = appFactory.Services;
            testClient = appFactory.CreateClient();
            _serviceScope = _serviceProvider.CreateScope();
        }

        protected async Task AuthenticateAsync(string username)
        {
            testClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await GetJwtAsync(username));
        }

        private async Task<string> GetJwtAsync(string email)
        {
            //var 

            var response = await testClient.PostAsJsonAsync(ApiRoutes.Identity.Login, new LoginRequest
            {
                Email = email,
                Password = "js7HL12sxnjk9876yh"
            });

            var registrationResponse = await response.Content.ReadFromJsonAsync<AuthSuccessResponse>();
            return registrationResponse.Token;
        }

        public virtual void Dispose()
        {
            using var serviceScope = _serviceProvider.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
            context.Database.EnsureDeleted();
            //context.Dispose();
        }



        protected async Task SeedUsers()
        {
            var roleManager = _serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = _serviceScope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            var roles = new[] { "SuperAdmin", "Admin", "User" };

            foreach (var role in roles)
            {
                if (await roleManager.RoleExistsAsync(role)) continue;

                var roleToCreate = new IdentityRole(role);
                await roleManager.CreateAsync(roleToCreate);
            }

            //move to seeder class
            foreach (var username in roles)
            {
                if (await userManager.FindByNameAsync(username) == null)
                {
                    var newUserId = Guid.NewGuid();
                    var newUserRole = username;
                    var newUser = new IdentityUser
                    {
                        Id = newUserId.ToString(),
                        UserName = username,
                        Email = username + "@test.com",
                        EmailConfirmed = true
                    };
                    // var createResponse = await userManager.CreateAsync(newUser, "Test1234.");
                    // var roleResponse = await userManager.AddToRoleAsync(newUser, username);
                }
            }
        }

    }
}

