using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Domain.Repositories;
using Restaurant.Infrastructure.Contexts;
using Restaurant.Infrastructure.Repositories;
using Restaurant.Infrastructure.Seeders;

namespace Restaurant.Infrastructure.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services , IConfiguration _config)
    {
        var connectionString = _config.GetConnectionString("LocalConnectionString");
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(connectionString)
            .EnableSensitiveDataLogging();
        });



        services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();
        services.AddScoped<IRestaurantsRepository, RestaurantsRepository>();




    }
}
