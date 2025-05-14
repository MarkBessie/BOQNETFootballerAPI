using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BOQNETFootballerAPI.Migrations
{
    /// <inheritdoc />
    public partial class FootballerStats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Footballer",
                newName: "FootballerId");

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "Footballer",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Club",
                table: "Footballer",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateTable(
                name: "FootballerMatchStats",
                columns: table => new
                {
                    FootballerMatchStatsId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FootballerId = table.Column<int>(type: "INTEGER", nullable: false),
                    MinutesPlayed = table.Column<int>(type: "INTEGER", nullable: false),
                    GoalsScored = table.Column<int>(type: "INTEGER", nullable: false),
                    Assists = table.Column<int>(type: "INTEGER", nullable: false),
                    PassCompletionPercentage = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootballerMatchStats", x => x.FootballerMatchStatsId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FootballerMatchStats");

            migrationBuilder.RenameColumn(
                name: "FootballerId",
                table: "Footballer",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "Footballer",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Club",
                table: "Footballer",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
