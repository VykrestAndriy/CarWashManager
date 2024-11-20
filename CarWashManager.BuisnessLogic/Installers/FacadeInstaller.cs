using Microsoft.Extensions.DependencyInjection;
using CarWashManager.BusinessLogic.Facades;
using CarWashManager.BusinessLogic.Contracts;
using CarWashManager.BusinessLogic.Services;
using CarWashManager.BuisnessLogic.Facades;

namespace CarWashManager.BusinessLogic.Facades
{
    public static class FacadeInstaller
    {
        public static IServiceCollection AddFacades(this IServiceCollection services)
        {
            services.AddScoped<WashTransactionFacade>();
            return services;
        }
    }
}