using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TechnicoApp.Models;


namespace TechnicoApp.Context;

public class TechnicoDbContext : DbContext
{
    public DbSet<PropertyItem> PropertyItems { get; set; }
    public DbSet<PropertyOwner> PropertyOwners { get; set; }
    public DbSet<PropertyRepair> PropertyRepairs { get; set; }
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

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PropertyItem>(entity =>
        {
            // Configure PropertyIdentificationNumber as the primary key
            entity.HasKey(e => e.PropertyIdentificationNumber);

            // Configure Id as an auto-generated column, not an identity
            entity.Property(e => e.Id)
                  .ValueGeneratedNever(); // This prevents Id from using the Identity property

            // Ensure PropertyIdentificationNumber does not use Identity
            entity.Property(e => e.PropertyIdentificationNumber)
                  .ValueGeneratedNever();
        });
    }


}





