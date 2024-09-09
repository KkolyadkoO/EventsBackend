using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class unique_title_of_category : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CategoryOfEventEntities_Title",
                table: "CategoryOfEventEntities",
                column: "Title",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CategoryOfEventEntities_Title",
                table: "CategoryOfEventEntities");
        }
    }
}
