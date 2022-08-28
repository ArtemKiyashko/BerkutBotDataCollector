using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BerkutBotDataCollector.DataAccess.Migrations
{
    public partial class AddIndexTelegramId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Chats_TelegramId",
                table: "Chats",
                column: "TelegramId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Chats_TelegramId",
                table: "Chats");
        }
    }
}
