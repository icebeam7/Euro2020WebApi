using Microsoft.EntityFrameworkCore.Migrations;

namespace Euro2020WebApi.Migrations
{
    public partial class FixTeamCoachRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coaches_Teams_EuroTeamId",
                table: "Coaches");

            migrationBuilder.DropIndex(
                name: "IX_Coaches_EuroTeamId",
                table: "Coaches");

            migrationBuilder.DropColumn(
                name: "EuroTeamId",
                table: "Coaches");

            migrationBuilder.AddColumn<int>(
                name: "EuroCoachId",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_EuroCoachId",
                table: "Teams",
                column: "EuroCoachId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Coaches_EuroCoachId",
                table: "Teams",
                column: "EuroCoachId",
                principalTable: "Coaches",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Coaches_EuroCoachId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_EuroCoachId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "EuroCoachId",
                table: "Teams");

            migrationBuilder.AddColumn<int>(
                name: "EuroTeamId",
                table: "Coaches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Coaches_EuroTeamId",
                table: "Coaches",
                column: "EuroTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Coaches_Teams_EuroTeamId",
                table: "Coaches",
                column: "EuroTeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
