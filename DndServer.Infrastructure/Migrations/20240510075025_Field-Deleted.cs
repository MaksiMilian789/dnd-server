using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DndServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FieldDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "World",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "SpellTemplate",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "SpellInstance",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "SkillTemplate",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "SkillInstance",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "RaceTemplate",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "RaceInstance",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "ObjectTemplate",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "ObjectInstance",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Image",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Conditions",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "ClassTemplate",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "ClassInstance",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Character",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "BackgroundTemplate",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "BackgroundInstance",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "World");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "SpellTemplate");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "SpellInstance");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "SkillTemplate");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "SkillInstance");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "RaceTemplate");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "RaceInstance");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "ObjectTemplate");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "ObjectInstance");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Conditions");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "ClassTemplate");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "ClassInstance");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "BackgroundTemplate");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "BackgroundInstance");
        }
    }
}
