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
    [Migration("20181127162318_[Estado-Formulario]")]
    partial class EstadoFormulario
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("SistemaTesis.Models.Formulario", b =>
                {
                    b.Property<int>("FormularioID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Abandono")
                        .HasMaxLength(100);

                    b.Property<int>("AccesoAgua")
                        .HasMaxLength(100);

                    b.Property<int>("AccesoElectricidad")
                        .HasMaxLength(100);

                    b.Property<int>("AguasResiduales")
                        .HasMaxLength(100);

                    b.Property<int>("Alcoholismo")
                        .HasMaxLength(100);

                    b.Property<int>("AsentamientoID");

                    b.Property<int>("ConPersoneria")
                        .HasMaxLength(100);

                    b.Property<int>("CondicionIrregular")
                        .HasMaxLength(100);

                    b.Property<string>("CuidoIndicadores")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("EdadProductiva")
                        .HasMaxLength(100);

                    b.Property<string>("EducacionPrimariaIndicadores")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("EducacionSecundariaIndicadores")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("EmbarazosAdolescentes")
                        .HasMaxLength(100);

                    b.Property<int>("Empleo")
                        .HasMaxLength(100);

                    b.Property<int>("EmpleoInfantil")
                        .HasMaxLength(100);

                    b.Property<int>("EmpleoInformal")
                        .HasMaxLength(100);

                    b.Property<bool>("Estado");

                    b.Property<string>("FamiliaIndicadores")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("FechaLlenado");

                    b.Property<int>("Hurtos")
                        .HasMaxLength(100);

                    b.Property<string>("IMASIndicadores")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Institucion")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("JefesHogar")
                        .HasMaxLength(100);

                    b.Property<int>("MiembroExtranjero")
                        .HasMaxLength(100);

                    b.Property<int>("MiembrosCostarricenses")
                        .HasMaxLength(100);

                    b.Property<string>("NombreEvaluador")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("NumCedula")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Observaciones")
                        .HasMaxLength(2000);

                    b.Property<int>("RecoleccionBasura")
                        .HasMaxLength(100);

                    b.Property<string>("RecreativoIndicadores")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("ResidenciaPermanente")
                        .HasMaxLength(100);

                    b.Property<string>("SaludIndicadores")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("SinPersoneria")
                        .HasMaxLength(100);

                    b.Property<string>("TenenciaIndicadores")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<double>("ValorFinal");

                    b.Property<int>("ViolenciaIntrafamiliar")
                        .HasMaxLength(100);

                    b.HasKey("FormularioID");

                    b.HasIndex("AsentamientoID");

                    b.ToTable("Formulario");
                });

            modelBuilder.Entity("SistemaTesis.Models.FormularioAmenaza", b =>
                {
                    b.Property<int>("FormularioAmenazaID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CatalogoAmenazaID");

                    b.Property<int>("FormularioID");

                    b.HasKey("FormularioAmenazaID");

                    b.HasIndex("CatalogoAmenazaID");

                    b.HasIndex("FormularioID");

                    b.ToTable("FormularioAmenaza");
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

                    b.HasKey("TipoDocumentoID");

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
                        .WithMany("Asentamientos")
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

            modelBuilder.Entity("SistemaTesis.Models.Formulario", b =>
                {
                    b.HasOne("SistemaTesis.Models.Asentamiento", "Asentamiento")
                        .WithMany("Formularios")
                        .HasForeignKey("AsentamientoID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SistemaTesis.Models.FormularioAmenaza", b =>
                {
                    b.HasOne("SistemaTesis.Models.CatalogoAmenaza", "CatalogoAmenaza")
                        .WithMany("FormulariosAmenazas")
                        .HasForeignKey("CatalogoAmenazaID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SistemaTesis.Models.Formulario", "Formulario")
                        .WithMany("FormulariosAmenazas")
                        .HasForeignKey("FormularioID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
