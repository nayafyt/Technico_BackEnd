using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TechnicoApp.Context;
using TechnicoApp.Domain.Interfaces;

using TechnicoApp.Models;
using TechnicoApp.Repositories;
using TechnicoApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add services to the container
builder.Services.AddDbContext<TechnicoDbContext>(options =>
    options.UseSqlServer("Data Source=localhost;Initial Catalog=Technico_DB;Trusted_Connection=True;TrustServerCertificate=True"));
builder.Services.AddScoped<IPropertyItemService, PropertyItemService>();
builder.Services.AddScoped<IPropertyOwnerService, PropertyOwnerService>();
builder.Services.AddScoped<IRepository<PropertyItem, long>, PropertyItemRepository>();
builder.Services.AddScoped<IPropertyRepository<PropertyItem,long>, PropertyItemRepository>();
builder.Services.AddScoped<IRepository<PropertyOwner, string>, PropertyOwnerRepository>();



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
