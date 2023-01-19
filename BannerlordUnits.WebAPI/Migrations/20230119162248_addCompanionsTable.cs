using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BannerlordUnits.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class addCompanionsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companions",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Culture = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
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
                    Engineering = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companions", x => x.Name);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companions");
        }
    }
}
