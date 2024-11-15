using CarWashManager.BusinessLogic.Installers;
using CarWashManager.DataAccess.Installers;
using CarWashManager.BuisnessLogic.Singleton;
using CarWashManager.BusinessLogic.Contracts;
using CarWashManager.BusinessLogic.Services;
using CarWashManager.DataAccess.RepositoriesWash.Wash;
using CarWashManager.DataAccess.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using CarWashManager.BusinessLogic.Adapters;
using CarWashManager.BuisnessLogic.Decorators;
using CarWashManager.DataAccess.Legacy;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<SingletonInstance>();
builder.Services.AddScoped<IWashRepository, WashRepository>();

builder.Services.AddScoped<IWashService, WashService>();

builder.Services.AddScoped<WashContext>();

builder.Services.AddTransient<IAdapterWashTransactionSystem, TransactionAdapter>();
builder.Services.AddTransient<LegacyTransactionAdapter>();
builder.Services.AddTransient<NewTransactionAdapter>();
builder.Services.AddTransient<LegacyTransactionSystem>();
builder.Services.AddTransient<NewTransactionSystem>();

builder.Services.Decorate<IWashService, WashServiceDecorator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
