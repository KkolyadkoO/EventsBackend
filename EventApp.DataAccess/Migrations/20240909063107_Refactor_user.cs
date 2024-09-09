using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Refactor_user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserEntities_UserEmail",
                table: "UserEntities",
                column: "UserEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserEntities_UserName",
                table: "UserEntities",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserEntities_UserEmail",
                table: "UserEntities");

            migrationBuilder.DropIndex(
                name: "IX_UserEntities_UserName",
                table: "UserEntities");
        }
    }
}
