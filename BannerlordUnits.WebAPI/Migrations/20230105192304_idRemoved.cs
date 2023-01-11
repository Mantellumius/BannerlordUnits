using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BannerlordUnits.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class idRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Units",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Units");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Units",
                table: "Units",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Units",
                table: "Units");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Units",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Units",
                table: "Units",
                columns: new[] { "Id", "Name" });
        }
    }
}
