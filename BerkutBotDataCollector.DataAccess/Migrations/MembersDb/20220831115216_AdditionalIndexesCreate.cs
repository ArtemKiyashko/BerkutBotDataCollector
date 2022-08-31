using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BerkutBotDataCollector.DataAccess.Migrations.MembersDb
{
    public partial class AdditionalIndexesCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Members_CreatedDateTime",
                table: "Members",
                column: "CreatedDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Members_UpdatedDateTime",
                table: "Members",
                column: "UpdatedDateTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Members_CreatedDateTime",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_UpdatedDateTime",
                table: "Members");
        }
    }
}
