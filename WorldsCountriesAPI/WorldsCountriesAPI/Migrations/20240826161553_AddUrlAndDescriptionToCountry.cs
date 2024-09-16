using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorldsCountriesAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddUrlAndDescriptionToCountry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Countries",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Countries",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Countries");
        }
    }
}
