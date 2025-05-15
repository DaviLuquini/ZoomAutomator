using DotNetEnv;
using ZoomAutomator.Application.Entities;
using ZoomAutomator.Application.Interfaces;
using ZoomAutomator.Application.Services;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

var clientId = Environment.GetEnvironmentVariable("ZOOM_CLIENT_ID");
var clientSecret = Environment.GetEnvironmentVariable("ZOOM_CLIENT_SECRET");
var accountId = Environment.GetEnvironmentVariable("ZOOM_ACCOUNT_ID");

// Add services to the container.
builder.Services.AddSingleton(new ZoomAuthConfig(clientId, clientSecret, accountId));
builder.Services.AddScoped<IZoomAuthService, ZoomAuthService>();
builder.Services.AddScoped<IZoomService, ZoomService>();

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
