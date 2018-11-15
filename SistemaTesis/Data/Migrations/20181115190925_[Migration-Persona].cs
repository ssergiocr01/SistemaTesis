using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SistemaTesis.Data.Migrations
{
    public partial class MigrationPersona : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Institucion",
                columns: table => new
                {
                    InstitucionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institucion", x => x.InstitucionID);
                });

            migrationBuilder.CreateTable(
                name: "TipoDocumento",
                columns: table => new
                {
                    TipoDocumentoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDocumento", x => x.TipoDocumentoID);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    InstitucionID = table.Column<int>(nullable: true),
                    PersonaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Apellidos = table.Column<string>(maxLength: 50, nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    InstitucionID2 = table.Column<int>(nullable: true),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    NumDocumento = table.Column<string>(nullable: true),
                    TipoDocumentoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.PersonaID);
                    table.ForeignKey(
                        name: "FK_Persona_Institucion_InstitucionID",
                        column: x => x.InstitucionID,
                        principalTable: "Institucion",
                        principalColumn: "InstitucionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Persona_Institucion_InstitucionID2",
                        column: x => x.InstitucionID2,
                        principalTable: "Institucion",
                        principalColumn: "InstitucionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persona_TipoDocumento_TipoDocumentoID",
                        column: x => x.TipoDocumentoID,
                        principalTable: "TipoDocumento",
                        principalColumn: "TipoDocumentoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persona_InstitucionID",
                table: "Persona",
                column: "InstitucionID");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_InstitucionID2",
                table: "Persona",
                column: "InstitucionID2");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_TipoDocumentoID",
                table: "Persona",
                column: "TipoDocumentoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "Institucion");

            migrationBuilder.DropTable(
                name: "TipoDocumento");
        }
    }
}
