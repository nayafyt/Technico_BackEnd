using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TechnicoApp.Domain.Models;


namespace TechnicoApp.Context;

public class TechnicoDbContext : DbContext
{
    public DbSet<PropertyItem> PropertyItems { get; set; }
    public DbSet<PropertyOwner> PropertyOwners { get; set; }
    //public DbSet<PropertyOwner> PropertyOwners { get; set; }
    //public DbSet<PropertyRepair> PropertyRepairs { get; set; }
    public TechnicoDbContext(DbContextOptions<TechnicoDbContext> options) : base(options)
    {
    }
    public TechnicoDbContext()
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Data Source = localhost; Initial Catalog = Technico_DB; Trusted_Connection = true; TrustServerCertificate = true");
        //optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.EnableSensitiveDataLogging();

    }


}

