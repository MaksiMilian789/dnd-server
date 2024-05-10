using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DndServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Wiki : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_World_Wiki_WikiKey",
                table: "World");

            migrationBuilder.DropIndex(
                name: "IX_World_WikiKey",
                table: "World");

            migrationBuilder.DropColumn(
                name: "WikiKey",
                table: "World");

            migrationBuilder.AddColumn<int>(
                name: "WorldId",
                table: "Wiki",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Wiki_WorldId",
                table: "Wiki",
                column: "WorldId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wiki_World_WorldId",
                table: "Wiki",
                column: "WorldId",
                principalTable: "World",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wiki_World_WorldId",
                table: "Wiki");

            migrationBuilder.DropIndex(
                name: "IX_Wiki_WorldId",
                table: "Wiki");

            migrationBuilder.DropColumn(
                name: "WorldId",
                table: "Wiki");

            migrationBuilder.AddColumn<int>(
                name: "WikiKey",
                table: "World",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_World_WikiKey",
                table: "World",
                column: "WikiKey",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_World_Wiki_WikiKey",
                table: "World",
                column: "WikiKey",
                principalTable: "Wiki",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
