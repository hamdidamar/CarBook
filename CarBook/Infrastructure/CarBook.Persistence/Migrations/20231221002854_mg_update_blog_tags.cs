using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mg_update_blog_tags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogTags_Blogs_BlogId1",
                table: "BlogTags");

            migrationBuilder.DropIndex(
                name: "IX_BlogTags_BlogId1",
                table: "BlogTags");

            migrationBuilder.DropColumn(
                name: "BlogId1",
                table: "BlogTags");

            migrationBuilder.AlterColumn<string>(
                name: "BlogId",
                table: "BlogTags",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_BlogTags_BlogId",
                table: "BlogTags",
                column: "BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogTags_Blogs_BlogId",
                table: "BlogTags",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogTags_Blogs_BlogId",
                table: "BlogTags");

            migrationBuilder.DropIndex(
                name: "IX_BlogTags_BlogId",
                table: "BlogTags");

            migrationBuilder.AlterColumn<int>(
                name: "BlogId",
                table: "BlogTags",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "BlogId1",
                table: "BlogTags",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_BlogTags_BlogId1",
                table: "BlogTags",
                column: "BlogId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogTags_Blogs_BlogId1",
                table: "BlogTags",
                column: "BlogId1",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
