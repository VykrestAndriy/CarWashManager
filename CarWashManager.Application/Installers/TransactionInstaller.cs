using CarWashManager.Application.Services;
using CarWashManager.Core.Contracts;
using Microsoft.Extensions.DependencyInjection;
namespace CarWashManager.Infrastructure.Installers;

   public static class TransactionInstaller
   {
     public static IServiceCollection AddTransactions(this IServiceCollection services)
     {
        services.AddScoped<ITransactionService, TransactionService>();
        return services;
     }
   }
