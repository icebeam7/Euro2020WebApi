using Microsoft.EntityFrameworkCore.Migrations;

namespace Euro2020WebApi.Migrations
{
    public partial class AddTeamFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupPosition",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupPosition",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Points",
                table: "Teams");
        }
    }
}
