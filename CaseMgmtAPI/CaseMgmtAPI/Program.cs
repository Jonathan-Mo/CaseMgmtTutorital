using CaseMgmtAPI.Infra;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;
//using CaseMgmtAPI.Test;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.File("logs/CMILog.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CaseMgmtContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddMediatR(typeof(Program).Assembly);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//builder.Services.AddHealthChecksUI().AddInMemoryStorage();
//builder.Services.AddHealthChecks()
//    //.AddCheck("Foo Service", () => HealthCheckResult.Healthy("The check of the foo service worked."), new[] { "service" })
//    //.AddCheck("Bar Service", () => HealthCheckResult.Healthy("The check of the foo service worked."), new[] { "service" })
//    .AddCheck<ResponseTimeHealthCheck>("Network spped test", null, new[] {"service"})
//    .AddCheck("Database", () => HealthCheckResult.Healthy("The check of the foo service worked."), new[] { "database", "sql" });
//builder.Services.AddSingleton<ResponseTimeHealthCheck>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.MapHealthChecksUI();

//app.MapHealthChecks("/health/services", new HealthCheckOptions()
//{
//    Predicate = reg => reg.Tags.Contains("service"),
//    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
//});
//app.MapHealthChecks("/health", new HealthCheckOptions()
//{
//    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
//});

app.MapControllers();

app.Run();
