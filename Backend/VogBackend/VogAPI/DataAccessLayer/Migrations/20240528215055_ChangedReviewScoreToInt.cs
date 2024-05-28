using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class ChangedReviewScoreToInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomUserListGames_CustomUserLists_CustomUserListId",
                table: "CustomUserListGames");

            migrationBuilder.DropIndex(
                name: "IX_CustomUserListGames_CustomUserListId",
                table: "CustomUserListGames");

            migrationBuilder.DropColumn(
                name: "CustomUserListId",
                table: "CustomUserListGames");

            migrationBuilder.AlterColumn<int>(
                name: "Score",
                table: "UserReviews",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_UserReviews_GameId",
                table: "UserReviews",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomUserLists_UserId",
                table: "CustomUserLists",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomUserLists_Users_UserId",
                table: "CustomUserLists",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserReviews_Games_GameId",
                table: "UserReviews",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomUserLists_Users_UserId",
                table: "CustomUserLists");

            migrationBuilder.DropForeignKey(
                name: "FK_UserReviews_Games_GameId",
                table: "UserReviews");

            migrationBuilder.DropIndex(
                name: "IX_UserReviews_GameId",
                table: "UserReviews");

            migrationBuilder.DropIndex(
                name: "IX_CustomUserLists_UserId",
                table: "CustomUserLists");

            migrationBuilder.AlterColumn<string>(
                name: "Score",
                table: "UserReviews",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CustomUserListId",
                table: "CustomUserListGames",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomUserListGames_CustomUserListId",
                table: "CustomUserListGames",
                column: "CustomUserListId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomUserListGames_CustomUserLists_CustomUserListId",
                table: "CustomUserListGames",
                column: "CustomUserListId",
                principalTable: "CustomUserLists",
                principalColumn: "Id");
        }
    }
}
