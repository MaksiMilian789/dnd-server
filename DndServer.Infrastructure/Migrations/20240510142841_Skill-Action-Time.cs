using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DndServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SkillActionTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ActionTime_Concentrate",
                table: "SkillTemplate",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ActionTime_Time",
                table: "SkillTemplate",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "ActionTime_Concentrate",
                table: "SkillInstance",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ActionTime_Time",
                table: "SkillInstance",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActionTime_Concentrate",
                table: "SkillTemplate");

            migrationBuilder.DropColumn(
                name: "ActionTime_Time",
                table: "SkillTemplate");

            migrationBuilder.DropColumn(
                name: "ActionTime_Concentrate",
                table: "SkillInstance");

            migrationBuilder.DropColumn(
                name: "ActionTime_Time",
                table: "SkillInstance");
        }
    }
}
