using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class addrelationrelatieinstallatie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RelatieId",
                table: "Installatie",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Installatie_RelatieId",
                table: "Installatie",
                column: "RelatieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Installatie_Relatie_RelatieId",
                table: "Installatie",
                column: "RelatieId",
                principalTable: "Relatie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Installatie_Relatie_RelatieId",
                table: "Installatie");

            migrationBuilder.DropIndex(
                name: "IX_Installatie_RelatieId",
                table: "Installatie");

            migrationBuilder.DropColumn(
                name: "RelatieId",
                table: "Installatie");
        }
    }
}
