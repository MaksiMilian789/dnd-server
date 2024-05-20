using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DndServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class imagebyte : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImageByte",
                table: "Image",
                type: "longblob",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageByte",
                table: "Image");
        }
    }
}
