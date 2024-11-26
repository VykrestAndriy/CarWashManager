using CarWashManager.Core.Contracts;
using CarWashManager.Application.Commands.Wash;
using CarWashManager.Application.Handlers.Wash;
using CarWashManager.Application;
using CarWashManager.Infrastructure.RepositoriesWash.Wash;
using CarWashManager.Core;
using CarWashManager.Application.Services;
using CarWashManager.Infrastructure;
using CarWashManager.Core.Handler;
using CarWashManager.Core.Handlers;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using MediatR;
using CarWashManager.Application.Handler;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

        builder.Services.AddScoped<IRequestHandler<UpdateWashCommand, bool>, UpdateWashCommandHandler>();

        builder.Services.AddScoped<DetergentHandler>();
        builder.Services.AddScoped<WashHandler>();
        builder.Services.AddScoped<PaymentHandler>();
        builder.Services.AddScoped<FeedbackHandler>();
        builder.Services.AddScoped<WashExecutionHandler>();

        builder.Services.AddScoped<IHandler>(serviceProvider =>
        {
            var detergentHandler = serviceProvider.GetRequiredService<DetergentHandler>();
            var washHandler = serviceProvider.GetRequiredService<WashHandler>();
            var paymentHandler = serviceProvider.GetRequiredService<PaymentHandler>();
            var feedbackHandler = serviceProvider.GetRequiredService<FeedbackHandler>();
            var washExecutionHandler = serviceProvider.GetRequiredService<WashExecutionHandler>();

            detergentHandler.SetNext(washHandler);
            washHandler.SetNext(paymentHandler);
            paymentHandler.SetNext(feedbackHandler);
            feedbackHandler.SetNext(washExecutionHandler);

            return detergentHandler;  
        });

        IServiceCollection serviceCollection = builder.Services.AddScoped<IWashService, WashService>();
        builder.Services.AddScoped<IWashRepository, WashRepository>();

        builder.Services.AddDbContext<WashContext>(options =>
            options.UseInMemoryDatabase("CarWashDatabase"));

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<WashContext>();
            WashContext.Seed(context);  
        }

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}
