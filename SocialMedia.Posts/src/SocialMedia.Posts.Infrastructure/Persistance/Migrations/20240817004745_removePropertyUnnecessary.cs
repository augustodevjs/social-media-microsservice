using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia.Posts.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class removePropertyUnnecessary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserDisplayName",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserDisplayName",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
