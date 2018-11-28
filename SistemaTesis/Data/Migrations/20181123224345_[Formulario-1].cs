using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SistemaTesis.Data.Migrations
{
    public partial class Formulario1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Formulario",
                columns: table => new
                {
                    FormularioID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Abandono = table.Column<int>(maxLength: 100, nullable: false),
                    AccesoAgua = table.Column<int>(maxLength: 100, nullable: false),
                    AccesoElectricidad = table.Column<int>(maxLength: 100, nullable: false),
                    AguasResiduales = table.Column<int>(maxLength: 100, nullable: false),
                    Alcoholismo = table.Column<int>(maxLength: 100, nullable: false),
                    AsentamientoID = table.Column<int>(nullable: false),
                    ConPersoneria = table.Column<int>(maxLength: 100, nullable: false),
                    CondicionIrregular = table.Column<int>(maxLength: 100, nullable: false),
                    CuidoIndicadores = table.Column<string>(maxLength: 100, nullable: false),
                    EdadProductiva = table.Column<int>(maxLength: 100, nullable: false),
                    EducacionPrimariaIndicadores = table.Column<string>(maxLength: 100, nullable: false),
                    EducacionSecundariaIndicadores = table.Column<string>(maxLength: 100, nullable: false),
                    EmbarazosAdolescentes = table.Column<int>(maxLength: 100, nullable: false),
                    Empleo = table.Column<int>(maxLength: 100, nullable: false),
                    EmpleoInfantil = table.Column<int>(maxLength: 100, nullable: false),
                    EmpleoInformal = table.Column<int>(maxLength: 100, nullable: false),
                    FamiliaIndicadores = table.Column<string>(maxLength: 100, nullable: false),
                    FechaLlenado = table.Column<DateTime>(nullable: false),
                    Hurtos = table.Column<int>(maxLength: 100, nullable: false),
                    IMASIndicadores = table.Column<string>(maxLength: 100, nullable: false),
                    JefesHogar = table.Column<int>(maxLength: 100, nullable: false),
                    MiembroExtranjero = table.Column<int>(maxLength: 100, nullable: false),
                    MiembrosCostarricenses = table.Column<int>(maxLength: 100, nullable: false),
                    RecoleccionBasura = table.Column<int>(maxLength: 100, nullable: false),
                    RecreativoIndicadores = table.Column<string>(maxLength: 100, nullable: false),
                    ResidenciaPermanente = table.Column<int>(maxLength: 100, nullable: false),
                    SaludIndicadores = table.Column<string>(maxLength: 100, nullable: false),
                    SinPersoneria = table.Column<int>(maxLength: 100, nullable: false),
                    TenenciaIndicadores = table.Column<string>(maxLength: 100, nullable: false),
                    ViolenciaIntrafamiliar = table.Column<int>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formulario", x => x.FormularioID);
                    table.ForeignKey(
                        name: "FK_Formulario_Asentamiento_AsentamientoID",
                        column: x => x.AsentamientoID,
                        principalTable: "Asentamiento",
                        principalColumn: "AsentamientoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormularioAmenaza",
                columns: table => new
                {
                    FormularioAmenazaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CatalogoAmenazaID = table.Column<int>(nullable: false),
                    FormularioID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormularioAmenaza", x => x.FormularioAmenazaID);
                    table.ForeignKey(
                        name: "FK_FormularioAmenaza_CatalogoAmenaza_CatalogoAmenazaID",
                        column: x => x.CatalogoAmenazaID,
                        principalTable: "CatalogoAmenaza",
                        principalColumn: "CatalogoAmenazaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormularioAmenaza_Formulario_FormularioID",
                        column: x => x.FormularioID,
                        principalTable: "Formulario",
                        principalColumn: "FormularioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Formulario_AsentamientoID",
                table: "Formulario",
                column: "AsentamientoID");

            migrationBuilder.CreateIndex(
                name: "IX_FormularioAmenaza_CatalogoAmenazaID",
                table: "FormularioAmenaza",
                column: "CatalogoAmenazaID");

            migrationBuilder.CreateIndex(
                name: "IX_FormularioAmenaza_FormularioID",
                table: "FormularioAmenaza",
                column: "FormularioID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormularioAmenaza");

            migrationBuilder.DropTable(
                name: "Formulario");
        }
    }
}
