﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechnicoApp.Context;

#nullable disable

namespace TechnicoApp.Migrations
{
    [DbContext(typeof(TechnicoDbContext))]
    [Migration("20250114143341_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PropertyOwner", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.Property<string>("VatNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PropertyOwners");
                });

            modelBuilder.Entity("TechnicoApp.Models.PropertyItem", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("PropertyIdentificationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PropertyOwnerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PropertyOwnerVatNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PropertyType")
                        .HasColumnType("int");

                    b.Property<int>("YearOfConstruction")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PropertyOwnerId");

                    b.ToTable("PropertyItems");
                });

            modelBuilder.Entity("TechnicoApp.Models.PropertyRepair", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("PropertyOwnerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PropertyOwnerVatNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("RepairType")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PropertyOwnerId");

                    b.HasIndex("PropertyOwnerVatNumber");

                    b.ToTable("PropertyRepairs");
                });

            modelBuilder.Entity("TechnicoApp.Models.PropertyItem", b =>
                {
                    b.HasOne("PropertyOwner", null)
                        .WithMany("PropertyItems")
                        .HasForeignKey("PropertyOwnerId");
                });

            modelBuilder.Entity("TechnicoApp.Models.PropertyRepair", b =>
                {
                    b.HasOne("PropertyOwner", null)
                        .WithMany("PropertyRepairs")
                        .HasForeignKey("PropertyOwnerId");

                    b.HasOne("TechnicoApp.Models.PropertyItem", "PropertyItem")
                        .WithMany("PropertyRepairs")
                        .HasForeignKey("PropertyOwnerVatNumber")
                        .HasPrincipalKey("PropertyIdentificationNumber");

                    b.Navigation("PropertyItem");
                });

            modelBuilder.Entity("PropertyOwner", b =>
                {
                    b.Navigation("PropertyItems");

                    b.Navigation("PropertyRepairs");
                });

            modelBuilder.Entity("TechnicoApp.Models.PropertyItem", b =>
                {
                    b.Navigation("PropertyRepairs");
                });
#pragma warning restore 612, 618
        }
    }
}
