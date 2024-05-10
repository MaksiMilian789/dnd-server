using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DndServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Uploads : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_Image_ImageId",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_Note_Image_ImageId",
                table: "Note");

            migrationBuilder.DropForeignKey(
                name: "FK_ObjectInstance_Image_ImageId",
                table: "ObjectInstance");

            migrationBuilder.DropForeignKey(
                name: "FK_ObjectTemplate_Image_ImageId",
                table: "ObjectTemplate");

            migrationBuilder.DropForeignKey(
                name: "FK_WikiPage_Image_ImageId",
                table: "WikiPage");

            migrationBuilder.DropForeignKey(
                name: "FK_World_Image_ImageId",
                table: "World");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Image",
                table: "Image");

            migrationBuilder.RenameTable(
                name: "Image",
                newName: "UploadFiles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UploadFiles",
                table: "UploadFiles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_UploadFiles_ImageId",
                table: "Character",
                column: "ImageId",
                principalTable: "UploadFiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Note_UploadFiles_ImageId",
                table: "Note",
                column: "ImageId",
                principalTable: "UploadFiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectInstance_UploadFiles_ImageId",
                table: "ObjectInstance",
                column: "ImageId",
                principalTable: "UploadFiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectTemplate_UploadFiles_ImageId",
                table: "ObjectTemplate",
                column: "ImageId",
                principalTable: "UploadFiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WikiPage_UploadFiles_ImageId",
                table: "WikiPage",
                column: "ImageId",
                principalTable: "UploadFiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_World_UploadFiles_ImageId",
                table: "World",
                column: "ImageId",
                principalTable: "UploadFiles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_UploadFiles_ImageId",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_Note_UploadFiles_ImageId",
                table: "Note");

            migrationBuilder.DropForeignKey(
                name: "FK_ObjectInstance_UploadFiles_ImageId",
                table: "ObjectInstance");

            migrationBuilder.DropForeignKey(
                name: "FK_ObjectTemplate_UploadFiles_ImageId",
                table: "ObjectTemplate");

            migrationBuilder.DropForeignKey(
                name: "FK_WikiPage_UploadFiles_ImageId",
                table: "WikiPage");

            migrationBuilder.DropForeignKey(
                name: "FK_World_UploadFiles_ImageId",
                table: "World");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UploadFiles",
                table: "UploadFiles");

            migrationBuilder.RenameTable(
                name: "UploadFiles",
                newName: "Image");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Image",
                table: "Image",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Image_ImageId",
                table: "Character",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Note_Image_ImageId",
                table: "Note",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectInstance_Image_ImageId",
                table: "ObjectInstance",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectTemplate_Image_ImageId",
                table: "ObjectTemplate",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WikiPage_Image_ImageId",
                table: "WikiPage",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_World_Image_ImageId",
                table: "World",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id");
        }
    }
}
