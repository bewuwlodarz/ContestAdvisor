using Microsoft.EntityFrameworkCore.Migrations;

namespace DanceCon.Migrations
{
    public partial class Initial6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "_UserID",
                table: "Contests",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "_UserID",
                table: "Contests",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
