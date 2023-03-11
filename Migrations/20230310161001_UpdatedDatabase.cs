using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KalanchoeAIBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfileImage",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MediaLink",
                table: "Saved",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MediaLink",
                table: "Posts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MediaLink",
                table: "MessageComments",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MediaLink",
                table: "Comments",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MediaLink",
                table: "ChannelComments",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileImage",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MediaLink",
                table: "Saved");

            migrationBuilder.DropColumn(
                name: "MediaLink",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "MediaLink",
                table: "MessageComments");

            migrationBuilder.DropColumn(
                name: "MediaLink",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "MediaLink",
                table: "ChannelComments");
        }
    }
}
