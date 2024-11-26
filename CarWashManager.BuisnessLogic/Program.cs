using CarWashManager.BusinessLogic.Contracts;
using CarWashManager.BusinessLogic.Handlers;
using CarWashManager.BusinessLogic.Services;
using CarWashManager.DataAccess.Entities;
using CarWashManager.DataAccess.RepositoriesWash.Wash;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Регистрация контроллеров, Swagger и других сервисов
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Регистрация обработчиков с помощью фабрики
builder.Services.AddScoped<IHandler>(serviceProvider =>
{
    // Получаем все обработчики
    var detergentHandler = serviceProvider.GetRequiredService<DetergentHandler>();
    var washHandler = serviceProvider.GetRequiredService<WashHandler>();
    var paymentHandler = serviceProvider.GetRequiredService<PaymentHandler>();
    var feedbackHandler = serviceProvider.GetRequiredService<FeedbackHandler>();
    var washExecutionHandler = serviceProvider.GetRequiredService<WashExecutionHandler>();

    // Создание цепочки обработчиков
    detergentHandler.SetNext(washHandler);
    washHandler.SetNext(paymentHandler);
    paymentHandler.SetNext(feedbackHandler);
    feedbackHandler.SetNext(washExecutionHandler);

    // Возвращаем первый обработчик
    return detergentHandler; // Начало цепочки
});

// Регистрация обработчиков по отдельности
builder.Services.AddScoped<DetergentHandler>();
builder.Services.AddScoped<WashHandler>();
builder.Services.AddScoped<PaymentHandler>();
builder.Services.AddScoped<FeedbackHandler>();
builder.Services.AddScoped<WashExecutionHandler>();

// Прочая регистрация сервисов
builder.Services.AddScoped<IWashService, WashService>();
builder.Services.AddScoped<IWashRepository, WashRepository>();

// Регистрация контекста базы данных
builder.Services.AddDbContext<WashContext>(options =>
    options.UseInMemoryDatabase("CarWashDatabase"));

var app = builder.Build();

// Инициализация базы данных и добавление начальных данных
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<WashContext>();
    WashContext.Seed(context);  // Метод для добавления начальных данных в базу
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
