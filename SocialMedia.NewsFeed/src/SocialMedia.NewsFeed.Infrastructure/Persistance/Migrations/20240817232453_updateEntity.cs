using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia.NewsFeed.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class updateEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_UserNewsfeeds_UserNewsfeedId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserNewsfeeds_Users_UserId",
                table: "UserNewsfeeds");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserNewsfeeds",
                table: "UserNewsfeeds");

            migrationBuilder.DropIndex(
                name: "IX_UserNewsfeeds_UserId",
                table: "UserNewsfeeds");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserNewsfeeds",
                table: "UserNewsfeeds",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_UserNewsfeeds_UserNewsfeedId",
                table: "Posts",
                column: "UserNewsfeedId",
                principalTable: "UserNewsfeeds",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_UserNewsfeeds_UserNewsfeedId",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserNewsfeeds",
                table: "UserNewsfeeds");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserNewsfeeds",
                table: "UserNewsfeeds",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserNewsfeeds_UserId",
                table: "UserNewsfeeds",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_UserNewsfeeds_UserNewsfeedId",
                table: "Posts",
                column: "UserNewsfeedId",
                principalTable: "UserNewsfeeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserNewsfeeds_Users_UserId",
                table: "UserNewsfeeds",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
