using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IncidentManagement.Repository.Migrations
{
    public partial class CreatedAndActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Incidents",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Incidents",
                nullable: false,
                defaultValue: DateTime.Now);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Incidents");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Incidents");
        }
    }
}
