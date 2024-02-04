using OrderTest.Application;
using OrderTest.Persistence;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfiguration) =>
    loggerConfiguration.ReadFrom.Configuration(context.Configuration));

var configuration = builder.Configuration;

builder.Services.AddPersistence(configuration);

builder.Services.RecreateDatabase();
builder.Services.FillTestData();

builder.Services.AddApplication();
builder.Services.AddApplicationCaching();
builder.Services.AddApplicationLogging();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

var app = builder.Build();

app.UseCors(corsPolicyBuilder =>
{
    corsPolicyBuilder.AllowAnyHeader();
    corsPolicyBuilder.AllowAnyMethod();
    corsPolicyBuilder.AllowAnyOrigin();
});

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();