using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BannerlordUnits.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class refactoredToParsedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.CreateTable(
                name: "CustomTroops",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Tier = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Culture = table.Column<string>(type: "text", nullable: true),
                    Wage = table.Column<int>(type: "integer", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    IconUrl = table.Column<string>(type: "text", nullable: true),
                    OneHanded = table.Column<int>(type: "integer", nullable: false),
                    TwoHanded = table.Column<int>(type: "integer", nullable: false),
                    Polearm = table.Column<int>(type: "integer", nullable: false),
                    Bow = table.Column<int>(type: "integer", nullable: false),
                    Crossbow = table.Column<int>(type: "integer", nullable: false),
                    Throwing = table.Column<int>(type: "integer", nullable: false),
                    Riding = table.Column<int>(type: "integer", nullable: false),
                    Athletics = table.Column<int>(type: "integer", nullable: false),
                    Crafting = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomTroops", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Troops",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    Tier = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Culture = table.Column<string>(type: "text", nullable: true),
                    Wage = table.Column<int>(type: "integer", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    IconUrl = table.Column<string>(type: "text", nullable: true),
                    OneHanded = table.Column<int>(type: "integer", nullable: false),
                    TwoHanded = table.Column<int>(type: "integer", nullable: false),
                    Polearm = table.Column<int>(type: "integer", nullable: false),
                    Bow = table.Column<int>(type: "integer", nullable: false),
                    Crossbow = table.Column<int>(type: "integer", nullable: false),
                    Throwing = table.Column<int>(type: "integer", nullable: false),
                    Riding = table.Column<int>(type: "integer", nullable: false),
                    Athletics = table.Column<int>(type: "integer", nullable: false),
                    Crafting = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Troops", x => x.Name);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomTroops");

            migrationBuilder.DropTable(
                name: "Troops");

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    Athletics = table.Column<int>(type: "integer", nullable: false),
                    Bow = table.Column<int>(type: "integer", nullable: false),
                    Charm = table.Column<int>(type: "integer", nullable: false),
                    Crafting = table.Column<int>(type: "integer", nullable: false),
                    Crossbow = table.Column<int>(type: "integer", nullable: false),
                    Culture = table.Column<string>(type: "text", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    Engineering = table.Column<int>(type: "integer", nullable: false),
                    IconUrl = table.Column<string>(type: "text", nullable: false),
                    Leadership = table.Column<int>(type: "integer", nullable: false),
                    Medicine = table.Column<int>(type: "integer", nullable: false),
                    OneHanded = table.Column<int>(type: "integer", nullable: false),
                    Polearm = table.Column<int>(type: "integer", nullable: false),
                    Range = table.Column<int>(type: "integer", nullable: false),
                    Riding = table.Column<int>(type: "integer", nullable: false),
                    Roguery = table.Column<int>(type: "integer", nullable: false),
                    Scouting = table.Column<int>(type: "integer", nullable: false),
                    Steward = table.Column<int>(type: "integer", nullable: false),
                    Tactics = table.Column<int>(type: "integer", nullable: false),
                    Throwing = table.Column<int>(type: "integer", nullable: false),
                    Trade = table.Column<int>(type: "integer", nullable: false),
                    TwoHanded = table.Column<int>(type: "integer", nullable: false),
                    UnitImageUrl = table.Column<string>(type: "text", nullable: false),
                    UpgradeCost = table.Column<int>(type: "integer", nullable: false),
                    Wages = table.Column<int>(type: "integer", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Name);
                });
        }
    }
}
