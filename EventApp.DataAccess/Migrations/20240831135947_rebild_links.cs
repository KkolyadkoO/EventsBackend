using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class rebild_links : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberOfEventEntities_EventEntities_EventEntityId",
                table: "MemberOfEventEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_MemberOfEventEntities_UserEntities_UserEntityId",
                table: "MemberOfEventEntities");

            migrationBuilder.DropIndex(
                name: "IX_MemberOfEventEntities_EventEntityId",
                table: "MemberOfEventEntities");

            migrationBuilder.DropIndex(
                name: "IX_MemberOfEventEntities_UserEntityId",
                table: "MemberOfEventEntities");

            migrationBuilder.DropColumn(
                name: "EventEntityId",
                table: "MemberOfEventEntities");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "MemberOfEventEntities");

            migrationBuilder.CreateIndex(
                name: "IX_MemberOfEventEntities_EventId",
                table: "MemberOfEventEntities",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberOfEventEntities_UserId",
                table: "MemberOfEventEntities",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MemberOfEventEntities_EventEntities_EventId",
                table: "MemberOfEventEntities",
                column: "EventId",
                principalTable: "EventEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberOfEventEntities_UserEntities_UserId",
                table: "MemberOfEventEntities",
                column: "UserId",
                principalTable: "UserEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberOfEventEntities_EventEntities_EventId",
                table: "MemberOfEventEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_MemberOfEventEntities_UserEntities_UserId",
                table: "MemberOfEventEntities");

            migrationBuilder.DropIndex(
                name: "IX_MemberOfEventEntities_EventId",
                table: "MemberOfEventEntities");

            migrationBuilder.DropIndex(
                name: "IX_MemberOfEventEntities_UserId",
                table: "MemberOfEventEntities");

            migrationBuilder.AddColumn<Guid>(
                name: "EventEntityId",
                table: "MemberOfEventEntities",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserEntityId",
                table: "MemberOfEventEntities",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MemberOfEventEntities_EventEntityId",
                table: "MemberOfEventEntities",
                column: "EventEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberOfEventEntities_UserEntityId",
                table: "MemberOfEventEntities",
                column: "UserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_MemberOfEventEntities_EventEntities_EventEntityId",
                table: "MemberOfEventEntities",
                column: "EventEntityId",
                principalTable: "EventEntities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MemberOfEventEntities_UserEntities_UserEntityId",
                table: "MemberOfEventEntities",
                column: "UserEntityId",
                principalTable: "UserEntities",
                principalColumn: "Id");
        }
    }
}
