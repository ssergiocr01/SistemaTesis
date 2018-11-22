﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SistemaTesis.Data;
using System;

namespace SistemaTesis.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SistemaTesis.Models.Amenaza", b =>
                {
                    b.Property<int>("AmenazaID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion")
                        .IsRequired();

                    b.Property<bool>("Estado");

                    b.Property<double>("Porcentaje");

                    b.HasKey("AmenazaID");

                    b.ToTable("Amenaza");
                });

            modelBuilder.Entity("SistemaTesis.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("SistemaTesis.Models.Asentamiento", b =>
                {
                    b.Property<int>("AsentamientoID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApellidosPropietario")
                        .IsRequired();

                    b.Property<int>("CantonID");

                    b.Property<string>("Coordenadas");

                    b.Property<string>("Direccion")
                        .IsRequired();

                    b.Property<int>("DistritoID");

                    b.Property<bool>("Estado");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("NombrePropietario")
                        .IsRequired();

                    b.Property<string>("NumDocumento")
                        .IsRequired();

                    b.Property<int>("NumViviendas");

                    b.Property<DateTime>("Ocupacion");

                    b.Property<int>("ProvinciaID");

                    b.Property<int>("TipoDocumentoID");

                    b.HasKey("AsentamientoID");

                    b.HasIndex("CantonID");

                    b.HasIndex("DistritoID");

                    b.HasIndex("ProvinciaID");

                    b.HasIndex("TipoDocumentoID");

                    b.ToTable("Asentamiento");
                });

            modelBuilder.Entity("SistemaTesis.Models.Canton", b =>
                {
                    b.Property<int>("CantonID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Estado");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("ProvinciaID");

                    b.HasKey("CantonID");

                    b.HasIndex("ProvinciaID");

                    b.ToTable("Canton");
                });

            modelBuilder.Entity("SistemaTesis.Models.CatalogoAmenaza", b =>
                {
                    b.Property<int>("CatalogoAmenazaID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AmenazaID");

                    b.Property<string>("Descripcion")
                        .IsRequired();

                    b.Property<bool>("Estado");

                    b.Property<double>("Porcentaje");

                    b.HasKey("CatalogoAmenazaID");

                    b.HasIndex("AmenazaID");

                    b.ToTable("CatalogoAmenaza");
                });

            modelBuilder.Entity("SistemaTesis.Models.Distrito", b =>
                {
                    b.Property<int>("DistritoID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CantonID");

                    b.Property<bool>("Estado");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("ProvinciaID");

                    b.HasKey("DistritoID");

                    b.HasIndex("CantonID");

                    b.HasIndex("ProvinciaID");

                    b.ToTable("Distrito");
                });

            modelBuilder.Entity("SistemaTesis.Models.Provincia", b =>
                {
                    b.Property<int>("ProvinciaID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Estado");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ProvinciaID");

                    b.ToTable("Provincia");
                });

            modelBuilder.Entity("SistemaTesis.Models.TipoDocumento", b =>
                {
                    b.Property<int>("TipoDocumentoID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion");

                    b.Property<bool>("Estado");

                    b.Property<int?>("TipoDocumentoID1");

                    b.HasKey("TipoDocumentoID");

                    b.HasIndex("TipoDocumentoID1");

                    b.ToTable("TipoDocumento");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SistemaTesis.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SistemaTesis.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SistemaTesis.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SistemaTesis.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SistemaTesis.Models.Asentamiento", b =>
                {
                    b.HasOne("SistemaTesis.Models.Canton", "Canton")
                        .WithMany("Asentamientos")
                        .HasForeignKey("CantonID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SistemaTesis.Models.Distrito", "Distrito")
                        .WithMany("Asentamientos")
                        .HasForeignKey("DistritoID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SistemaTesis.Models.Provincia", "Provincia")
                        .WithMany("Asentamientos")
                        .HasForeignKey("ProvinciaID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SistemaTesis.Models.TipoDocumento", "TipoDocumento")
                        .WithMany()
                        .HasForeignKey("TipoDocumentoID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SistemaTesis.Models.Canton", b =>
                {
                    b.HasOne("SistemaTesis.Models.Provincia", "Provincia")
                        .WithMany("Cantones")
                        .HasForeignKey("ProvinciaID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SistemaTesis.Models.CatalogoAmenaza", b =>
                {
                    b.HasOne("SistemaTesis.Models.Amenaza", "Amenaza")
                        .WithMany("CatalogosAmenazas")
                        .HasForeignKey("AmenazaID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SistemaTesis.Models.Distrito", b =>
                {
                    b.HasOne("SistemaTesis.Models.Canton", "Canton")
                        .WithMany("Distritos")
                        .HasForeignKey("CantonID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SistemaTesis.Models.Provincia", "Provincia")
                        .WithMany("Distritos")
                        .HasForeignKey("ProvinciaID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SistemaTesis.Models.TipoDocumento", b =>
                {
                    b.HasOne("SistemaTesis.Models.TipoDocumento")
                        .WithMany("TiposDocumentos")
                        .HasForeignKey("TipoDocumentoID1");
                });
#pragma warning restore 612, 618
        }
    }
}
