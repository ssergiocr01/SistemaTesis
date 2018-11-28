using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SistemaTesis.Data.Migrations
{
    public partial class cambiomodeloasentamiento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Coordenadas",
                table: "Asentamiento",
                newName: "Longitud");

            migrationBuilder.AddColumn<string>(
                name: "Latitud",
                table: "Asentamiento",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitud",
                table: "Asentamiento");

            migrationBuilder.RenameColumn(
                name: "Longitud",
                table: "Asentamiento",
                newName: "Coordenadas");
        }
    }
}
