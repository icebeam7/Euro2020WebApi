using Microsoft.EntityFrameworkCore.Migrations;

namespace Euro2020WebApi.Migrations
{
    public partial class AddCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stadiums_Countries_EuroCountryId",
                table: "Stadiums");

            migrationBuilder.RenameColumn(
                name: "EuroCountryId",
                table: "Stadiums",
                newName: "EuroCityId");

            migrationBuilder.RenameIndex(
                name: "IX_Stadiums_EuroCountryId",
                table: "Stadiums",
                newName: "IX_Stadiums_EuroCityId");

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EuroCountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_EuroCountryId",
                        column: x => x.EuroCountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_EuroCountryId",
                table: "Cities",
                column: "EuroCountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stadiums_Cities_EuroCityId",
                table: "Stadiums",
                column: "EuroCityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stadiums_Cities_EuroCityId",
                table: "Stadiums");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.RenameColumn(
                name: "EuroCityId",
                table: "Stadiums",
                newName: "EuroCountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Stadiums_EuroCityId",
                table: "Stadiums",
                newName: "IX_Stadiums_EuroCountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stadiums_Countries_EuroCountryId",
                table: "Stadiums",
                column: "EuroCountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
