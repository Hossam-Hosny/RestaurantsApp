using Microsoft.OpenApi;
using Restaurant.API.Middlewares;
using Serilog;

namespace Restaurant.API.Extensions;

public static class WebCollectionExtensions
{
    public static void AddPresentaion (this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

        builder.Services.AddScoped<ErrorHandlingMiddleware>();
        builder.Services.AddScoped<RequestTimeLoggingMiddleware>();



        builder.Services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
            });
           
        });
    }
}
