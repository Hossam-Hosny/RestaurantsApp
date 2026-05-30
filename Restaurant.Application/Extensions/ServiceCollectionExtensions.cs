using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Application.Users;

namespace Restaurant.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        var appAssemblley = typeof(ServiceCollectionExtensions).Assembly;

        // registering MediatR
       services.AddMediatR(cfg=>cfg.RegisterServicesFromAssembly(appAssemblley));

        // registering AutoMapper
        services.AddAutoMapper(cfg => { },appAssemblley);

        // registering Fluent validation
        services.AddValidatorsFromAssembly(appAssemblley)
            .AddFluentValidationAutoValidation();

        services.AddScoped<IUserContext, UserContext>();
        services.AddHttpContextAccessor();

    }
}
