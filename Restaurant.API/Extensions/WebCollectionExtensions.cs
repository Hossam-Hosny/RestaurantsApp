using Serilog;

namespace Restaurant.API.Extensions;

public static class WebCollectionExtensions
{
    public static void AddPresentaion (this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));




    }
}
