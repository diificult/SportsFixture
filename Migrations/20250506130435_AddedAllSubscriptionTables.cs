using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsFixture.Migrations
{
    /// <inheritdoc />
    public partial class AddedAllSubscriptionTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompetitionSubscription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CompetitionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionSubscription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompetitionSubscription_Events_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Events",
                        principalColumn: "SportEventID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompetitionSubscription_Subscriptions_Id",
                        column: x => x.Id,
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FixtureSubscription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FixtureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixtureSubscription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FixtureSubscription_SportsFixture_FixtureId",
                        column: x => x.FixtureId,
                        principalTable: "SportsFixture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FixtureSubscription_Subscriptions_Id",
                        column: x => x.Id,
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionSubscription_CompetitionId",
                table: "CompetitionSubscription",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_FixtureSubscription_FixtureId",
                table: "FixtureSubscription",
                column: "FixtureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompetitionSubscription");

            migrationBuilder.DropTable(
                name: "FixtureSubscription");
        }
    }
}
