using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DndServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SpellAddFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasDamage",
                table: "SpellTemplate",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MagicSchool",
                table: "SpellTemplate",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "HasDamage",
                table: "SpellInstance",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MagicSchool",
                table: "SpellInstance",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasDamage",
                table: "SpellTemplate");

            migrationBuilder.DropColumn(
                name: "MagicSchool",
                table: "SpellTemplate");

            migrationBuilder.DropColumn(
                name: "HasDamage",
                table: "SpellInstance");

            migrationBuilder.DropColumn(
                name: "MagicSchool",
                table: "SpellInstance");
        }
    }
}
