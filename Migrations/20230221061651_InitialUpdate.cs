using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KalanchoeAIBackend.Migrations
{
    /// <inheritdoc />
    public partial class InitialUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FollowerUser",
                table: "Followers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ChannelCommentValue",
                table: "ChannelComments",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FollowerUser",
                table: "Followers");

            migrationBuilder.AlterColumn<string>(
                name: "ChannelCommentValue",
                table: "ChannelComments",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }
    }
}
