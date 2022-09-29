using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaseMgmtAPI.Migrations
{
    public partial class AddStatusAndNotesEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Cases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Cases",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Cases");
        }
    }
}
