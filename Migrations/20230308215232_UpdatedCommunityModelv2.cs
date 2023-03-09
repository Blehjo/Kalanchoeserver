using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KalanchoeAIBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedCommunityModelv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MediaLink",
                table: "Communities");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MediaLink",
                table: "Communities",
                type: "TEXT",
                nullable: true);
        }
    }
}
