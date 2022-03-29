using Microsoft.EntityFrameworkCore.Migrations;

namespace Euro2020WebApi.Migrations
{
    public partial class RemovePosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Positions_EuroPositionId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_EuroPositionId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "EuroPositionId",
                table: "Teams");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EuroPositionId",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_EuroPositionId",
                table: "Teams",
                column: "EuroPositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Positions_EuroPositionId",
                table: "Teams",
                column: "EuroPositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
