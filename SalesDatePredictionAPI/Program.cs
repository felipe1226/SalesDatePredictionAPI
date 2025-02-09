using SalesDatePredictionAPI.DI;
using SalesDatePredictionAPI.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

builder.Services.AddControllers();

DBConnection dbConnection = DBConnection.Instance;
dbConnection.setConnectionString(builder.Configuration);

DependencyInjection.RegisterProfile(builder.Services);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
