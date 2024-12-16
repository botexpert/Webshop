using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Webshop.Application.Interfaces;
using Webshop.Domain.Interfaces;
using Webshop.Infrastructure.Data;
using Webshop.Infrastructure.Services;

namespace Webshop.Infrastructure;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration,
        IHostEnvironment env)
    {
        //DbContext
        var dbPath = configuration.GetConnectionString("DefaultConnection");
        var databasePath = Path.Combine(env.ContentRootPath, dbPath);

        services.AddDbContext<WebshopDbContext>(options =>
            options.UseSqlite($"Data Source={databasePath}"));

        //Repositories
        services.AddScoped<IShopItemRepository, ShopItemRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();

        //Services
        services.AddScoped<IShopItemService, ShopItemService>();
        services.AddScoped<ILoginService, LoginService>();

        return services;
    }
}