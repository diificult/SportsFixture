using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsFixture.Migrations
{
    /// <inheritdoc />
    public partial class TeamSubscription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeamSubscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamSubscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamSubscriptions_SportTeams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "SportTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamSubscriptions_Subscriptions_Id",
                        column: x => x.Id,
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamSubscriptions_TeamId",
                table: "TeamSubscriptions",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamSubscriptions");
        }
    }
}
