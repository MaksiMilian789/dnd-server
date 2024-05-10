using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DndServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TimeSpanToInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ActionTime_Time",
                table: "SpellTemplate",
                type: "int",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time(6)");

            migrationBuilder.AlterColumn<int>(
                name: "ActionTime_Time",
                table: "SpellInstance",
                type: "int",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time(6)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "ActionTime_Time",
                table: "SpellTemplate",
                type: "time(6)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "ActionTime_Time",
                table: "SpellInstance",
                type: "time(6)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
