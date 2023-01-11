using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BannerlordUnits.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class removeCraftingSkill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Crafting",
                table: "Troops");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Crafting",
                table: "Troops",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
