using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class rebild_links_event : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_EventEntities_CategoryId",
                table: "EventEntities",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventEntities_CategoryOfEventEntities_CategoryId",
                table: "EventEntities",
                column: "CategoryId",
                principalTable: "CategoryOfEventEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventEntities_CategoryOfEventEntities_CategoryId",
                table: "EventEntities");

            migrationBuilder.DropIndex(
                name: "IX_EventEntities_CategoryId",
                table: "EventEntities");
        }
    }
}
