using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using WebApi.API.Services;
using WebApi.Application;
using WebApi.Infrastructure.Services;
using WebApi.Persistence.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Adding Fluent Validation
builder.Services.AddControllers().AddFluentValidation(x=>x.RegisterValidatorsFromAssemblyContaining<Program>());



// Bogus library for create fake data
builder.Services.AddScoped<FakeDataService>();

// Caching
builder.Services.AddMemoryCache();

// Week 10 ConfigurationService homework
builder.Services.AddSingleton<IConfigurationService, ConfigurationService>();

var connectionString = builder.Configuration.GetSection("YetgenPostgreSQLDB").Value;

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(connectionString);
});

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

app.UseAuthorization();

app.MapControllers();

app.Run();
