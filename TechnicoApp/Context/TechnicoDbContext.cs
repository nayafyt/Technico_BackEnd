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

        modelBuilder.Entity<PropertyRepair>()
                    .Property(p => p.Cost)
                    .HasColumnType("decimal(18,2)");


        modelBuilder.Entity<PropertyRepair>()
        .HasOne(pr => pr.PropertyOwner)
        .WithMany(po => po.PropertyRepairs)
        .HasForeignKey("PropertyOwnerVatNumber") // Database column for the foreign key
        .HasPrincipalKey(po => po.VatNumber);
    }


}





