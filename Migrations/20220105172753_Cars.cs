using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class Cars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarsCar_Id",
                table: "Car",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Car_CarsCar_Id",
                table: "Car",
                column: "CarsCar_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Car_CarsCar_Id",
                table: "Car",
                column: "CarsCar_Id",
                principalTable: "Car",
                principalColumn: "Car_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Car_CarsCar_Id",
                table: "Car");

            migrationBuilder.DropIndex(
                name: "IX_Car_CarsCar_Id",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "CarsCar_Id",
                table: "Car");
        }
    }
}
