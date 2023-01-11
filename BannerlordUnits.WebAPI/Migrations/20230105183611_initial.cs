using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BannerlordUnits.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Culture = table.Column<int>(type: "integer", nullable: false),
                    Wages = table.Column<int>(type: "integer", nullable: false),
                    UpgradeCost = table.Column<int>(type: "integer", nullable: false),
                    IconUrl = table.Column<string>(type: "text", nullable: false),
                    UnitImageUrl = table.Column<string>(type: "text", nullable: false),
                    OneHanded = table.Column<int>(type: "integer", nullable: false),
                    TwoHanded = table.Column<int>(type: "integer", nullable: false),
                    Polearm = table.Column<int>(type: "integer", nullable: false),
                    Bow = table.Column<int>(type: "integer", nullable: false),
                    Crossbow = table.Column<int>(type: "integer", nullable: false),
                    Throwing = table.Column<int>(type: "integer", nullable: false),
                    Riding = table.Column<int>(type: "integer", nullable: false),
                    Athletics = table.Column<int>(type: "integer", nullable: false),
                    Crafting = table.Column<int>(type: "integer", nullable: false),
                    Scouting = table.Column<int>(type: "integer", nullable: false),
                    Tactics = table.Column<int>(type: "integer", nullable: false),
                    Roguery = table.Column<int>(type: "integer", nullable: false),
                    Charm = table.Column<int>(type: "integer", nullable: false),
                    Leadership = table.Column<int>(type: "integer", nullable: false),
                    Trade = table.Column<int>(type: "integer", nullable: false),
                    Steward = table.Column<int>(type: "integer", nullable: false),
                    Medicine = table.Column<int>(type: "integer", nullable: false),
                    Engineering = table.Column<int>(type: "integer", nullable: false),
                    Range = table.Column<int>(type: "integer", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => new { x.Id, x.Name });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}
