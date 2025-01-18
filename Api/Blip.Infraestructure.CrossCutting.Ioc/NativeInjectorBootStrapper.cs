using Microsoft.Extensions.DependencyInjection;
using Blip.Infraestructure.Services;
using Blip.Core.Interfaces.Infreastructure.Services;
using Blip.Core.Notifications;
using Blip.Core.Interfaces.Notifications;

namespace Blip.Infraestructure.CrossCutting.Ioc;

public static class NativeInjectorBootStrapper
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IGithubService, GithubService>();
        services.AddScoped<INotifier, Notifier>();        
    }
}