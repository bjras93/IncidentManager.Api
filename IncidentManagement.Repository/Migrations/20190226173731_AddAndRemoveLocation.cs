using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IncidentManagement.Repository.Migrations
{
    public partial class AddAndRemoveLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MachineId",
                table: "Incidents",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Machine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    LocationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Machine_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_MachineId",
                table: "Incidents",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_Machine_LocationId",
                table: "Machine",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_Machine_MachineId",
                table: "Incidents",
                column: "MachineId",
                principalTable: "Machine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_Machine_MachineId",
                table: "Incidents");

            migrationBuilder.DropTable(
                name: "Machine");

            migrationBuilder.DropIndex(
                name: "IX_Incidents_MachineId",
                table: "Incidents");

            migrationBuilder.DropColumn(
                name: "MachineId",
                table: "Incidents");
        }
    }
}
