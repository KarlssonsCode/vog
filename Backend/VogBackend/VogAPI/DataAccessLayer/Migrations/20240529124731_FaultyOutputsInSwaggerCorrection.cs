using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class FaultyOutputsInSwaggerCorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomUserListId",
                table: "CustomUserListGames",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CustomUserListGames_CustomUserListId",
                table: "CustomUserListGames",
                column: "CustomUserListId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomUserListGames_CustomUserLists_CustomUserListId",
                table: "CustomUserListGames",
                column: "CustomUserListId",
                principalTable: "CustomUserLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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
        }
    }
}
