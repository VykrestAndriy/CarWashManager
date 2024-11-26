using Microsoft.Extensions.DependencyInjection;
using CarWashManager.Core.Contracts;
using CarWashManager.Core.Enums;
using CarWashManager.Application.Services;

namespace CarWashManager.Application.Installers;

public static class WashInstaller
{
    public static IServiceCollection AddWashs(this IServiceCollection services)
    {
        services.AddScoped<IWashService, WashService>();
        return services;
    }
}
