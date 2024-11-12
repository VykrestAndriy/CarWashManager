using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using CarWashManager.BusinessLogic.Contracts;
using CarWashManager.BusinessLogic.Services;

namespace CarWashManager.BusinessLogic.Installers;

public static class WashInstaller
{
    public static IServiceCollection AddWashs(this IServiceCollection services)
    {
        services.AddScoped<IWashService, WashService>();
        return services;
    }
}
