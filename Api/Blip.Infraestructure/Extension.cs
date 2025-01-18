using Blip.Core.Configurations;
using Microsoft.Extensions.DependencyInjection;

namespace Blip.Infraestructure;

public static class Extension
{
    public static IServiceCollection ConfigureApiUrls(this IServiceCollection services)
    {
        services.AddOptions<Apis>()
               .BindConfiguration("APIs")
               .ValidateDataAnnotations()
               .ValidateOnStart();

        return services;
    }
}