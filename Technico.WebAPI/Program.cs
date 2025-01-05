using System.Configuration;
using Microsoft.EntityFrameworkCore;
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
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IPropertyItemService, PropertyItemService>();
builder.Services.AddScoped<IPropertyOwnerService, PropertyOwnerService>();
builder.Services.AddScoped<IPropertyRepairService, PropertyRepairService>();

builder.Services.AddScoped<IRepository<PropertyItem, long>, PropertyItemRepository>();
builder.Services.AddScoped<IRepository<PropertyOwner, string>, PropertyOwnerRepository>();
builder.Services.AddScoped<IRepository<PropertyRepair, long>, PropertyRepairRepository>();

builder.Services.AddScoped<IPropertyRepository<PropertyItem,long>, PropertyItemRepository>();






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
