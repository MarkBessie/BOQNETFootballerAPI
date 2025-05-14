using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BOQNETFootballerAPI.Migrations
{
    /// <inheritdoc />
    public partial class Opposition_FootballerMatchStats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Opposition",
                table: "FootballerMatchStats",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Opposition",
                table: "FootballerMatchStats");
        }
    }
}
