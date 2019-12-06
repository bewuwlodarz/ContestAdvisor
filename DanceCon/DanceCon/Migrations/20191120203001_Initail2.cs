using Microsoft.EntityFrameworkCore.Migrations;

namespace DanceCon.Migrations
{
    public partial class Initail2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "_ContestID",
                table: "Judges",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "_ContestID",
                table: "Judges");
        }
    }
}
