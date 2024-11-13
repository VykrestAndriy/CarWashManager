using CarWashManager.BusinessLogic.Installers;
using CarWashManager.DataAccess.Installers;
using CarWashManager.BuisnessLogic.Singleton;
using CarWashManager.BusinessLogic.Contracts;
using CarWashManager.BusinessLogic.Services;
using CarWashManager.DataAccess.RepositoriesWash.Wash;
using CarWashManager.DataAccess.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<SingletonInstance>();
builder.Services.AddScoped<IWashRepository, WashRepository>();
builder.Services.AddScoped<IWashService, WashService>();
builder.Services.AddScoped<WashContext>();
builder.Services.AddScoped<IWashRepository, WashRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
