using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BerkutBotDataCollector.DataAccess.Migrations
{
    public partial class AddChatFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Chats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Chats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Chats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Chats");
        }
    }
}
