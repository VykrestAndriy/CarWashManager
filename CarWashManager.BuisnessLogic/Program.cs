using CarWashManager.BusinessLogic.Contracts;
using CarWashManager.BusinessLogic.Handlers;
using CarWashManager.BusinessLogic.Services;
using CarWashManager.DataAccess.Entities;
using CarWashManager.DataAccess.RepositoriesWash.Wash;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ����������� ������������, Swagger � ������ ��������
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ����������� ������������ � ������� �������
builder.Services.AddScoped<IHandler>(serviceProvider =>
{
    // �������� ��� �����������
    var detergentHandler = serviceProvider.GetRequiredService<DetergentHandler>();
    var washHandler = serviceProvider.GetRequiredService<WashHandler>();
    var paymentHandler = serviceProvider.GetRequiredService<PaymentHandler>();
    var feedbackHandler = serviceProvider.GetRequiredService<FeedbackHandler>();
    var washExecutionHandler = serviceProvider.GetRequiredService<WashExecutionHandler>();

    // �������� ������� ������������
    detergentHandler.SetNext(washHandler);
    washHandler.SetNext(paymentHandler);
    paymentHandler.SetNext(feedbackHandler);
    feedbackHandler.SetNext(washExecutionHandler);

    // ���������� ������ ����������
    return detergentHandler; // ������ �������
});

// ����������� ������������ �� �����������
builder.Services.AddScoped<DetergentHandler>();
builder.Services.AddScoped<WashHandler>();
builder.Services.AddScoped<PaymentHandler>();
builder.Services.AddScoped<FeedbackHandler>();
builder.Services.AddScoped<WashExecutionHandler>();

// ������ ����������� ��������
builder.Services.AddScoped<IWashService, WashService>();
builder.Services.AddScoped<IWashRepository, WashRepository>();

// ����������� ��������� ���� ������
builder.Services.AddDbContext<WashContext>(options =>
    options.UseInMemoryDatabase("CarWashDatabase"));

var app = builder.Build();

// ������������� ���� ������ � ���������� ��������� ������
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<WashContext>();
    WashContext.Seed(context);  // ����� ��� ���������� ��������� ������ � ����
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
