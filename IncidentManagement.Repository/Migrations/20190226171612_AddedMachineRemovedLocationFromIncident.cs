using Microsoft.EntityFrameworkCore.Migrations;

namespace IncidentManagement.Repository.Migrations
{
    public partial class AddedMachineRemovedLocationFromIncident : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_Location_LocationId",
                table: "Incidents");

            migrationBuilder.DropIndex(
                name: "IX_Incidents_LocationId",
                table: "Incidents");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Incidents");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Incidents",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_LocationId",
                table: "Incidents",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_Location_LocationId",
                table: "Incidents",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
