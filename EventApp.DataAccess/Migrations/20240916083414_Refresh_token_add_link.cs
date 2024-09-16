using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Refresh_token_add_link : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokenEntities_UserId",
                table: "RefreshTokenEntities",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokenEntities_UserEntities_UserId",
                table: "RefreshTokenEntities",
                column: "UserId",
                principalTable: "UserEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokenEntities_UserEntities_UserId",
                table: "RefreshTokenEntities");

            migrationBuilder.DropIndex(
                name: "IX_RefreshTokenEntities_UserId",
                table: "RefreshTokenEntities");
        }
    }
}
