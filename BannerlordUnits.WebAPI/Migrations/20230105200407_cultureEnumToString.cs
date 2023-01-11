using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BannerlordUnits.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class cultureEnumToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Culture",
                table: "Units",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Culture",
                table: "Units",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
