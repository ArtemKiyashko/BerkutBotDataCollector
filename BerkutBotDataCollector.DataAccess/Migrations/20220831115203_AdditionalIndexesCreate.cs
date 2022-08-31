using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BerkutBotDataCollector.DataAccess.Migrations
{
    public partial class AdditionalIndexesCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Chats_CreatedDateTime",
                table: "Chats",
                column: "CreatedDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_UpdatedDateTime",
                table: "Chats",
                column: "UpdatedDateTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Chats_CreatedDateTime",
                table: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_Chats_UpdatedDateTime",
                table: "Chats");
        }
    }
}
