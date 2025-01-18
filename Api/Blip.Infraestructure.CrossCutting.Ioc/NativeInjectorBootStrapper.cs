using Microsoft.Extensions.DependencyInjection;
using Blip.Infraestructure.Services;
using Blip.Core.Interfaces.Infreastructure.Services;
namespace Blip.Infraestructure.CrossCutting.Ioc;

public static class NativeInjectorBootStrapper
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IGithubService, GithubService>();       
    }
}