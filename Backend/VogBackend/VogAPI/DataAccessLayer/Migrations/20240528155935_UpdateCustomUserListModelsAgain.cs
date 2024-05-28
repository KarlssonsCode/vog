using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCustomUserListModelsAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomUserListGames_CustomUserLists_ListId",
                table: "CustomUserListGames");

            migrationBuilder.DropIndex(
                name: "IX_CustomUserListGames_ListId",
                table: "CustomUserListGames");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_CustomUserListGames_ListId",
                table: "CustomUserListGames",
                column: "ListId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomUserListGames_CustomUserLists_ListId",
                table: "CustomUserListGames",
                column: "ListId",
                principalTable: "CustomUserLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
