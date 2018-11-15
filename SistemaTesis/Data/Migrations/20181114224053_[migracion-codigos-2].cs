using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SistemaTesis.Data.Migrations
{
    public partial class migracioncodigos2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodProvi",
                table: "Provincia");

            migrationBuilder.DropColumn(
                name: "CodDistrito",
                table: "Distrito");

            migrationBuilder.DropColumn(
                name: "CodCanton",
                table: "Canton");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodProvi",
                table: "Provincia",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodDistrito",
                table: "Distrito",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodCanton",
                table: "Canton",
                nullable: true);
        }
    }
}
