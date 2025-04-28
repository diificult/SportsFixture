using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsFixture.Migrations
{
    /// <inheritdoc />
    public partial class CreatedMainSportsFeatures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fixture");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "SportsFixture",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SportCompetitionId",
                table: "SportsFixture",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SportId",
                table: "SportsFixture",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StatusShort",
                table: "SportsFixture",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    SportEventID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SportEventName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.SportEventID);
                });

            migrationBuilder.CreateTable(
                name: "Sports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SportTeams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SportId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    APIid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportTeams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SportTeams_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MatchEvent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Referee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AwayResults = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeTeamId = table.Column<int>(type: "int", nullable: false),
                    AwayTeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchEvent_SportTeams_AwayTeamId",
                        column: x => x.AwayTeamId,
                        principalTable: "SportTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatchEvent_SportTeams_HomeTeamId",
                        column: x => x.HomeTeamId,
                        principalTable: "SportTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatchEvent_SportsFixture_Id",
                        column: x => x.Id,
                        principalTable: "SportsFixture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SportsFixture_SportCompetitionId",
                table: "SportsFixture",
                column: "SportCompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_SportsFixture_SportId",
                table: "SportsFixture",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchEvent_AwayTeamId",
                table: "MatchEvent",
                column: "AwayTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchEvent_HomeTeamId",
                table: "MatchEvent",
                column: "HomeTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_SportTeams_SportId",
                table: "SportTeams",
                column: "SportId");

            migrationBuilder.AddForeignKey(
                name: "FK_SportsFixture_Events_SportCompetitionId",
                table: "SportsFixture",
                column: "SportCompetitionId",
                principalTable: "Events",
                principalColumn: "SportEventID");

            migrationBuilder.AddForeignKey(
                name: "FK_SportsFixture_Sports_SportId",
                table: "SportsFixture",
                column: "SportId",
                principalTable: "Sports",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SportsFixture_Events_SportCompetitionId",
                table: "SportsFixture");

            migrationBuilder.DropForeignKey(
                name: "FK_SportsFixture_Sports_SportId",
                table: "SportsFixture");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "MatchEvent");

            migrationBuilder.DropTable(
                name: "SportTeams");

            migrationBuilder.DropTable(
                name: "Sports");

            migrationBuilder.DropIndex(
                name: "IX_SportsFixture_SportCompetitionId",
                table: "SportsFixture");

            migrationBuilder.DropIndex(
                name: "IX_SportsFixture_SportId",
                table: "SportsFixture");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "SportsFixture");

            migrationBuilder.DropColumn(
                name: "SportCompetitionId",
                table: "SportsFixture");

            migrationBuilder.DropColumn(
                name: "SportId",
                table: "SportsFixture");

            migrationBuilder.DropColumn(
                name: "StatusShort",
                table: "SportsFixture");

            migrationBuilder.CreateTable(
                name: "Fixture",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Referee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusShort = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fixture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fixture_SportsFixture_Id",
                        column: x => x.Id,
                        principalTable: "SportsFixture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
