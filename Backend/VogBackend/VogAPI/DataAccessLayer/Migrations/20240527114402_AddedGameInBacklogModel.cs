using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddedGameInBacklogModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ReviewText",
                table: "UserReviews",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_CustomUserListGames_GameId",
                table: "CustomUserListGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Backlogs_UserId",
                table: "Backlogs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Backlogs_Users_UserId",
                table: "Backlogs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomUserListGames_Games_GameId",
                table: "CustomUserListGames",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Backlogs_Users_UserId",
                table: "Backlogs");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomUserListGames_Games_GameId",
                table: "CustomUserListGames");

            migrationBuilder.DropIndex(
                name: "IX_CustomUserListGames_GameId",
                table: "CustomUserListGames");

            migrationBuilder.DropIndex(
                name: "IX_Backlogs_UserId",
                table: "Backlogs");

            migrationBuilder.AlterColumn<string>(
                name: "ReviewText",
                table: "UserReviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
