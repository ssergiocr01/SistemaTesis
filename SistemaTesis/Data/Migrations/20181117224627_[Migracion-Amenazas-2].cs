using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SistemaTesis.Data.Migrations
{
    public partial class MigracionAmenazas2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Amenaza",
                newName: "Porcentaje");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Porcentaje",
                table: "Amenaza",
                newName: "Value");
        }
    }
}
