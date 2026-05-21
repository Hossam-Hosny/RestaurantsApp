using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Application.Restaurants;

namespace Restaurant.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        var appAssemblley = typeof(ServiceCollectionExtensions).Assembly;

        services.AddScoped<IRestaurantsService, RestaurantsService>();

        // registering AutoMapper
        services.AddAutoMapper(appAssemblley);

        // registering Fluent validation
        services.AddValidatorsFromAssembly(appAssemblley)
            .AddFluentValidationAutoValidation();

    }
}
