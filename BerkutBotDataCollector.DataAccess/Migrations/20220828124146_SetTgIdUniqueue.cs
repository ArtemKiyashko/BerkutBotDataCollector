using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BerkutBotDataCollector.DataAccess.Migrations
{
    public partial class SetTgIdUniqueue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Chats_TelegramId",
                table: "Chats");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_TelegramId",
                table: "Chats",
                column: "TelegramId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Chats_TelegramId",
                table: "Chats");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_TelegramId",
                table: "Chats",
                column: "TelegramId");
        }
    }
}
