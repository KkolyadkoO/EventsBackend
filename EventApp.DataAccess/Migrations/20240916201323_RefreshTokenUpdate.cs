using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RefreshTokenUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRevoked",
                table: "RefreshTokenEntities");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRevoked",
                table: "RefreshTokenEntities",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
