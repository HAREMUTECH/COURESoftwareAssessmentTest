using COURESoftwareAssessmentTest.WebApi.Data;
using COURESoftwareAssessmentTest.WebApi.Dto;
using COURESoftwareAssessmentTest.WebApi.Repository;
using COURESoftwareAssessmentTest.WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.File("./Logs/log.json", rollingInterval: RollingInterval.Day)
    .CreateLogger();


builder.Host.UseSerilog();


builder.Services.AddApiVersioning(config =>
{
    config.DefaultApiVersion = new ApiVersion(1, 0);
    config.AssumeDefaultVersionWhenUnspecified = true;
    config.ReportApiVersions = true;
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("InMemoryDb"));

//Repositories
builder.Services.AddTransient<ICountryRepository, CountryRepository>();


//Services
builder.Services.AddTransient<ICountryServices, CountryServices>();





builder.Services.AddCors(options => options.AddPolicy(MyAllowSpecificOrigins, builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    CountryDataSeeder.Seed(dbContext);
}

app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();

app.UseSwaggerUI(s => s.SwaggerEndpoint("/openapi/v1.json", "COURE Software Assessment Test"));

app.UseAuthorization();
app.UseRouting();

app.MapControllers();

app.Run();
