using CarWashManager.DataAccess;
using Microsoft.Extensions.DependencyInjection;
using CarWashManager.DataAccess.RepositoriesWash.Wash;
using CarWashManager.DataAccess.RepositoriesWash.Transaction;


namespace CarWashManager.DataAccess.Installers;

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