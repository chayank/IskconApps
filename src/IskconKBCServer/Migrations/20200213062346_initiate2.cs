using Microsoft.EntityFrameworkCore.Migrations;

namespace IskconKBCServer.Migrations
{
    public partial class initiate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DevoteeSkill",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DevoteeId = table.Column<int>(nullable: false),
                    Learning = table.Column<string>(nullable: true),
                    Teaching = table.Column<string>(nullable: true),
                    UsingInYatra = table.Column<string>(nullable: true),
                    HaveTheSkills = table.Column<string>(nullable: true),
                    SpecialSkills = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevoteeSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DevoteeSkill_Devotee_DevoteeId",
                        column: x => x.DevoteeId,
                        principalTable: "Devotee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DevoteeSkill_DevoteeId",
                table: "DevoteeSkill",
                column: "DevoteeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DevoteeSkill");
        }
    }
}
