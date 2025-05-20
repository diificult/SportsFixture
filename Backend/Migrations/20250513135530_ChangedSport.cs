using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsFixture.Migrations
{
    /// <inheritdoc />
    public partial class ChangedSport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Sports");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Sports",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Sports");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Sports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
