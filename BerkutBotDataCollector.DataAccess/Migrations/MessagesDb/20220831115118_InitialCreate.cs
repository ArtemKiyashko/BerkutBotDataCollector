using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BerkutBotDataCollector.DataAccess.Migrations.MessagesDb
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    HorizontalAccuracy = table.Column<float>(type: "real", nullable: true),
                    LivePeriod = table.Column<int>(type: "int", nullable: true),
                    Heading = table.Column<int>(type: "int", nullable: true),
                    ProximityAlertRadius = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelegramFromId = table.Column<long>(type: "bigint", nullable: false),
                    TelegramChatId = table.Column<long>(type: "bigint", nullable: false),
                    MessageType = table.Column<int>(type: "int", nullable: false),
                    SentDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TelegramId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    MessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TelegramFileId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelegramFileUniqueId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelegramFileSize = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photo_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_CreatedDateTime",
                table: "Messages",
                column: "CreatedDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_LocationId",
                table: "Messages",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SentDateTime",
                table: "Messages",
                column: "SentDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_TelegramChatId",
                table: "Messages",
                column: "TelegramChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_TelegramFromId",
                table: "Messages",
                column: "TelegramFromId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_TelegramId",
                table: "Messages",
                column: "TelegramId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UpdatedDateTime",
                table: "Messages",
                column: "UpdatedDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_MessageId",
                table: "Photo",
                column: "MessageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Location");
        }
    }
}
