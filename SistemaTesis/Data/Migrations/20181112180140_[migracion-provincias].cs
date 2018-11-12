using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SistemaTesis.Data.Migrations
{
    public partial class migracionprovincias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Provincia",
                columns: table => new
                {
                    ProvinciaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Estado = table.Column<bool>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincia", x => x.ProvinciaID);
                });

            migrationBuilder.CreateTable(
                name: "Canton",
                columns: table => new
                {
                    CantonID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Estado = table.Column<bool>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    ProvinciaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canton", x => x.CantonID);
                    table.ForeignKey(
                        name: "FK_Canton_Provincia_ProvinciaID",
                        column: x => x.ProvinciaID,
                        principalTable: "Provincia",
                        principalColumn: "ProvinciaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Distrito",
                columns: table => new
                {
                    DistritoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CantonID = table.Column<int>(nullable: false),
                    Estado = table.Column<bool>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    ProvinciaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distrito", x => x.DistritoID);
                    table.ForeignKey(
                        name: "FK_Distrito_Canton_CantonID",
                        column: x => x.CantonID,
                        principalTable: "Canton",
                        principalColumn: "CantonID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Distrito_Provincia_ProvinciaID",
                        column: x => x.ProvinciaID,
                        principalTable: "Provincia",
                        principalColumn: "ProvinciaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Asentamiento",
                columns: table => new
                {
                    AsentamientoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CantonID = table.Column<int>(nullable: false),
                    Coordenadas = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    DistritoID = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    NumViviendas = table.Column<int>(nullable: false),
                    Ocupacion = table.Column<DateTime>(nullable: false),
                    PropietarioID = table.Column<int>(nullable: false),
                    ProvinciaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asentamiento", x => x.AsentamientoID);
                    table.ForeignKey(
                        name: "FK_Asentamiento_Canton_CantonID",
                        column: x => x.CantonID,
                        principalTable: "Canton",
                        principalColumn: "CantonID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Asentamiento_Distrito_DistritoID",
                        column: x => x.DistritoID,
                        principalTable: "Distrito",
                        principalColumn: "DistritoID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Asentamiento_Provincia_ProvinciaID",
                        column: x => x.ProvinciaID,
                        principalTable: "Provincia",
                        principalColumn: "ProvinciaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asentamiento_CantonID",
                table: "Asentamiento",
                column: "CantonID");

            migrationBuilder.CreateIndex(
                name: "IX_Asentamiento_DistritoID",
                table: "Asentamiento",
                column: "DistritoID");

            migrationBuilder.CreateIndex(
                name: "IX_Asentamiento_ProvinciaID",
                table: "Asentamiento",
                column: "ProvinciaID");

            migrationBuilder.CreateIndex(
                name: "IX_Canton_ProvinciaID",
                table: "Canton",
                column: "ProvinciaID");

            migrationBuilder.CreateIndex(
                name: "IX_Distrito_CantonID",
                table: "Distrito",
                column: "CantonID");

            migrationBuilder.CreateIndex(
                name: "IX_Distrito_ProvinciaID",
                table: "Distrito",
                column: "ProvinciaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asentamiento");

            migrationBuilder.DropTable(
                name: "Distrito");

            migrationBuilder.DropTable(
                name: "Canton");

            migrationBuilder.DropTable(
                name: "Provincia");
        }
    }
}
