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

builder.Services.AddScoped<IRepository<PropertyItem, string>, PropertyItemRepository>();
builder.Services.AddScoped<IRepository<PropertyOwner, string>, PropertyOwnerRepository>();
builder.Services.AddScoped<IRepository<PropertyRepair, long>, PropertyRepairRepository>();

builder.Services.AddScoped<IPropertyRepository<PropertyItem,string>, PropertyItemRepository>();
builder.Services.AddScoped<IPropertyRepository<PropertyRepair, long>, PropertyRepairRepository>();
builder.Services.AddScoped<IPropertyRepairRepository, PropertyRepairRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseCors("AllowLocalhost");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
