using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia.NewsFeed.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class updatePostEntityNewsFeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Posts",
                newName: "PostId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "Posts",
                newName: "Id");
        }
    }
}
