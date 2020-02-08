using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IskconKBCServer.Data.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DevoteeDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DevoteeId = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    InitiatedName = table.Column<string>(nullable: true),
                    Sex = table.Column<int>(nullable: false),
                    Dob = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Profession = table.Column<string>(nullable: true),
                    MobileNo = table.Column<string>(nullable: true),
                    WhatsappMobileNo = table.Column<string>(nullable: true),
                    EmergencyContactName = table.Column<int>(nullable: false),
                    EmergencyContactMobileNo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevoteeDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DevoteeDetails_AspNetUsers_DevoteeId",
                        column: x => x.DevoteeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DevoteeDetails_DevoteeId",
                table: "DevoteeDetails",
                column: "DevoteeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DevoteeDetails");
        }
    }
}
