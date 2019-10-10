using Microsoft.EntityFrameworkCore.Migrations;

namespace Bazzar.Infrastructures.Data.SqlServer.Migrations
{
    public partial class addversiontoroot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Version",
                table: "UserProfiles",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Version",
                table: "Advertisments",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Advertisments");
        }
    }
}
