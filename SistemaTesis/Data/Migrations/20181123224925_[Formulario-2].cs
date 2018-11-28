using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SistemaTesis.Data.Migrations
{
    public partial class Formulario2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Institucion",
                table: "Formulario",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NombreEvaluador",
                table: "Formulario",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NumCedula",
                table: "Formulario",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Observaciones",
                table: "Formulario",
                maxLength: 2000,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Institucion",
                table: "Formulario");

            migrationBuilder.DropColumn(
                name: "NombreEvaluador",
                table: "Formulario");

            migrationBuilder.DropColumn(
                name: "NumCedula",
                table: "Formulario");

            migrationBuilder.DropColumn(
                name: "Observaciones",
                table: "Formulario");
        }
    }
}
