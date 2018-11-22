using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SistemaTesis.Data.Migrations
{
    public partial class asentamientos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NumDocumento",
                table: "Asentamiento",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "NumDocumento",
                table: "Asentamiento",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
