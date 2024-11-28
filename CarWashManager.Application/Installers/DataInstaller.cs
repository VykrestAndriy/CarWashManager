using Microsoft.Extensions.DependencyInjection;
using CarWashManager.Infrastructure.RepositoriesWash.Wash;
using CarWashManager.Infrastructure.RepositoriesWash.Transaction;

namespace CarWashManager.Infrastructure.Installers;

public static class DataInstaller
{
    public static IServiceCollection AddDataContext(this IServiceCollection services)
    {
        services
            .AddTransient<ITransactionRepository, TransactionRepository>()
            .AddTransient<IWashRepository, WashRepository>();
        return services;
    }
}