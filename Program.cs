using KalanchoeAI_Backend.Data;
using Microsoft.AspNetCore.Session;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using KalanchoeAI_Backend.Models.Users;
using OpenAI.GPT3.Extensions;
using OpenAI.GPT3.Interfaces;
using System.Configuration;
using KalanchoeAI_Backend.Helpers;
using KalanchoeAI_Backend.Services;
using KalanchoeAI_Backend.Authorization;

var builder = WebApplication.CreateBuilder(args);

{
    var services = builder.Services;
    var env = builder.Environment;

    services.AddCors();
    services.AddControllers();

    // configure automapper with all automapper profiles from this assembly
    services.AddAutoMapper(typeof(Program));

    // configure strongly typed settings object
    services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

    // configure DI for application services
    services.AddScoped<IJwtUtils, JwtUtils>();
    services.AddScoped<IUserService, UserService>();
}

builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Services.AddOpenAIService();

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<KalanchoeAIDatabaseContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("KalanchoeAIDatabaseContext") ?? throw new InvalidOperationException("Connection string 'KalanchoeAIDatabaseContext' not found.")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

{
    // global cors policy
    app.UseCors(x => x
        .WithOrigins("https://localhost:44498")
        .AllowAnyMethod()
        .AllowCredentials()
        .AllowAnyHeader());

    // global error handler
    app.UseMiddleware<ErrorHandlerMiddleware>();

    // custom jwt auth middleware
    app.UseMiddleware<KalanchoeAI_Backend.Authorization.JwtMiddleware>();

    app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");
}

app.UseAuthorization();

app.Run();