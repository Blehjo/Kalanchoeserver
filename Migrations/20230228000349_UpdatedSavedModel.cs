using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KalanchoeAIBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedSavedModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MediaLink",
                table: "Saved",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MediaLink",
                table: "Saved");
        }
    }
}
