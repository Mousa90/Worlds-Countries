using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorldsCountriesAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddFlagUrlToCountry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Countries",
                newName: "ImageUrl");

            migrationBuilder.AddColumn<string>(
                name: "FlagUrl",
                table: "Countries",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlagUrl",
                table: "Countries");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Countries",
                newName: "Url");
        }
    }
}
