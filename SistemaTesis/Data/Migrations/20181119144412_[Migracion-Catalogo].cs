using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SistemaTesis.Data.Migrations
{
    public partial class MigracionCatalogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CatalogoAmenaza",
                columns: table => new
                {
                    CatalogoAmenazaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AmenazaID = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: false),
                    Estado = table.Column<bool>(nullable: false),
                    Porcentaje = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogoAmenaza", x => x.CatalogoAmenazaID);
                    table.ForeignKey(
                        name: "FK_CatalogoAmenaza_Amenaza_AmenazaID",
                        column: x => x.AmenazaID,
                        principalTable: "Amenaza",
                        principalColumn: "AmenazaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatalogoAmenaza_AmenazaID",
                table: "CatalogoAmenaza",
                column: "AmenazaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogoAmenaza");
        }
    }
}
