using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mg_add_rentAcar_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentACars_Cars_CarId1",
                table: "RentACars");

            migrationBuilder.DropIndex(
                name: "IX_RentACars_CarId1",
                table: "RentACars");

            migrationBuilder.DropColumn(
                name: "CarId1",
                table: "RentACars");

            migrationBuilder.AlterColumn<string>(
                name: "PickUpLocationId",
                table: "RentACars",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CarId",
                table: "RentACars",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_RentACars_CarId",
                table: "RentACars",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentACars_Cars_CarId",
                table: "RentACars",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentACars_Cars_CarId",
                table: "RentACars");

            migrationBuilder.DropIndex(
                name: "IX_RentACars_CarId",
                table: "RentACars");

            migrationBuilder.AlterColumn<int>(
                name: "PickUpLocationId",
                table: "RentACars",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "RentACars",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "CarId1",
                table: "RentACars",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_RentACars_CarId1",
                table: "RentACars",
                column: "CarId1");

            migrationBuilder.AddForeignKey(
                name: "FK_RentACars_Cars_CarId1",
                table: "RentACars",
                column: "CarId1",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
