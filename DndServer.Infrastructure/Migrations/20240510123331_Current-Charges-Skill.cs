using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DndServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CurrentChargesSkill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentCharges",
                table: "SkillInstance",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentCharges",
                table: "SkillInstance");
        }
    }
}
