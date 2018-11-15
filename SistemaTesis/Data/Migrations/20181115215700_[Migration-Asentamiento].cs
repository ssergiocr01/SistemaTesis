using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SistemaTesis.Data.Migrations
{
    public partial class MigrationAsentamiento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "Institucion");

            migrationBuilder.RenameColumn(
                name: "PropietarioID",
                table: "Asentamiento",
                newName: "TipoDocumentoID");

            migrationBuilder.AddColumn<int>(
                name: "TipoDocumentoID1",
                table: "TipoDocumento",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Asentamiento",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApellidosPropietario",
                table: "Asentamiento",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NombrePropietario",
                table: "Asentamiento",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NumDocumento",
                table: "Asentamiento",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TipoDocumento_TipoDocumentoID1",
                table: "TipoDocumento",
                column: "TipoDocumentoID1");

            migrationBuilder.CreateIndex(
                name: "IX_Asentamiento_TipoDocumentoID",
                table: "Asentamiento",
                column: "TipoDocumentoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Asentamiento_TipoDocumento_TipoDocumentoID",
                table: "Asentamiento",
                column: "TipoDocumentoID",
                principalTable: "TipoDocumento",
                principalColumn: "TipoDocumentoID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TipoDocumento_TipoDocumento_TipoDocumentoID1",
                table: "TipoDocumento",
                column: "TipoDocumentoID1",
                principalTable: "TipoDocumento",
                principalColumn: "TipoDocumentoID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asentamiento_TipoDocumento_TipoDocumentoID",
                table: "Asentamiento");

            migrationBuilder.DropForeignKey(
                name: "FK_TipoDocumento_TipoDocumento_TipoDocumentoID1",
                table: "TipoDocumento");

            migrationBuilder.DropIndex(
                name: "IX_TipoDocumento_TipoDocumentoID1",
                table: "TipoDocumento");

            migrationBuilder.DropIndex(
                name: "IX_Asentamiento_TipoDocumentoID",
                table: "Asentamiento");

            migrationBuilder.DropColumn(
                name: "TipoDocumentoID1",
                table: "TipoDocumento");

            migrationBuilder.DropColumn(
                name: "ApellidosPropietario",
                table: "Asentamiento");

            migrationBuilder.DropColumn(
                name: "NombrePropietario",
                table: "Asentamiento");

            migrationBuilder.DropColumn(
                name: "NumDocumento",
                table: "Asentamiento");

            migrationBuilder.RenameColumn(
                name: "TipoDocumentoID",
                table: "Asentamiento",
                newName: "PropietarioID");

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Asentamiento",
                nullable: true,
                oldClrType: typeof(string));

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
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
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
    }
}
