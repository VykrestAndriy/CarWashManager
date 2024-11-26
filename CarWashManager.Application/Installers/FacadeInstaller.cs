using Microsoft.Extensions.DependencyInjection;


namespace CarWashManager.Application.Facades
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