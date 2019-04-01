using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IncidentManagement.Repository.Migrations
{
    public partial class AddedProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Location");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Header = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<int>(nullable: true),
                    AssignedToId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_Users_AssignedToId",
                        column: x => x.AssignedToId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProjectId",
                table: "Comments",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_AssignedToId",
                table: "Project",
                column: "AssignedToId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_CreatedById",
                table: "Project",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Project_ProjectId",
                table: "Comments",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Project_ProjectId",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ProjectId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Comments");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Location",
                nullable: true);
        }
    }
}
