﻿using DataManager.Data;
using DataManager.Library.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataManager.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
                options
                .UseSqlServer(
                    configuration
                    .GetConnectionString("IdentityConnection"))
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors());

            services.AddSingleton<IUserData>(x => ActivatorUtilities.CreateInstance<UserData>(x, configuration.GetConnectionString("DefaultConnection")));
            services.AddSingleton<IProductData>(x => ActivatorUtilities.CreateInstance<ProductData>(x, configuration.GetConnectionString("DefaultConnection")));
            services.AddSingleton<ISaleData>(x => ActivatorUtilities.CreateInstance<SaleData>(x, configuration.GetConnectionString("DefaultConnection")));
            services.AddSingleton<IInventoryData>(x => ActivatorUtilities.CreateInstance<InventoryData>(x, configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
