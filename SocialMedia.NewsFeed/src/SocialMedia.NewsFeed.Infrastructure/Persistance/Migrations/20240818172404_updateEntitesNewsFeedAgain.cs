using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia.NewsFeed.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class updateEntitesNewsFeedAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_UserNewsfeeds_UserNewsfeedId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_UserNewsfeedId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "UserNewsfeedId",
                table: "Posts");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Posts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_UserNewsfeeds_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "UserNewsfeeds",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_UserNewsfeeds_UserId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_UserId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Posts");

            migrationBuilder.AddColumn<Guid>(
                name: "UserNewsfeedId",
                table: "Posts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserNewsfeedId",
                table: "Posts",
                column: "UserNewsfeedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_UserNewsfeeds_UserNewsfeedId",
                table: "Posts",
                column: "UserNewsfeedId",
                principalTable: "UserNewsfeeds",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
