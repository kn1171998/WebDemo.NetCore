using Microsoft.EntityFrameworkCore.Migrations;

namespace PayComputePersistence.Migrations
{
    public partial class editstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Relatives",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Locations",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "LocationEmployees",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Relatives");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Locations",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "LocationEmployees",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool));
        }
    }
}
