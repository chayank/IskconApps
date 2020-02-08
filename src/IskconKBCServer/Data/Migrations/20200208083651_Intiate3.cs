using Microsoft.EntityFrameworkCore.Migrations;

namespace IskconKBCServer.Data.Migrations
{
    public partial class Intiate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DevoteeLanguageProficiencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DevoteeId = table.Column<string>(nullable: true),
                    Speak = table.Column<string>(nullable: true),
                    Read = table.Column<string>(nullable: true),
                    Write = table.Column<string>(nullable: true),
                    MotherTongue = table.Column<string>(nullable: true),
                    TranslatableFromEnglish = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevoteeLanguageProficiencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DevoteeLanguageProficiencies_AspNetUsers_DevoteeId",
                        column: x => x.DevoteeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DevoteeLanguageProficiencies_DevoteeId",
                table: "DevoteeLanguageProficiencies",
                column: "DevoteeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DevoteeLanguageProficiencies");
        }
    }
}
