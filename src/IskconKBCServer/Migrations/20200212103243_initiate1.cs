using Microsoft.EntityFrameworkCore.Migrations;

namespace IskconKBCServer.Migrations
{
    public partial class initiate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MotherTongue",
                table: "DevoteeLanguageProficiency",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MotherTongue",
                table: "DevoteeLanguageProficiency",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
