using Microsoft.EntityFrameworkCore.Migrations;

namespace PayComputePersistence.Migrations
{
    public partial class updatelocationemployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "StatusJoindLocation",
                table: "LocationEmployees",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusJoindLocation",
                table: "LocationEmployees");
        }
    }
}
