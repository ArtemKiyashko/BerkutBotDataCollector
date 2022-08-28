using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BerkutBotDataCollector.DataAccess.Migrations.MembersDb
{
    public partial class SetTgIdUniqueue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Members_TelegramId",
                table: "Members");

            migrationBuilder.CreateIndex(
                name: "IX_Members_TelegramId",
                table: "Members",
                column: "TelegramId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Members_TelegramId",
                table: "Members");

            migrationBuilder.CreateIndex(
                name: "IX_Members_TelegramId",
                table: "Members",
                column: "TelegramId");
        }
    }
}
