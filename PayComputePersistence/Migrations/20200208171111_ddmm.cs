using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PayComputePersistence.Migrations
{
    public partial class ddmm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Relationship",
                table: "Relatives",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<int>(
                name: "PaymentMethod",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateTable(
                name: "TimekeepingEMPs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTimeKeeping = table.Column<DateTime>(nullable: false),
                    StartTimeKeeping = table.Column<TimeSpan>(nullable: false),
                    EndTimeKeeping = table.Column<TimeSpan>(nullable: false),
                    Reason = table.Column<string>(nullable: true),
                    Furlough = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimekeepingEMPs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimekeepingEMPs_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimekeepingEMPs_EmployeeId",
                table: "TimekeepingEMPs",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimekeepingEMPs");

            migrationBuilder.AlterColumn<string>(
                name: "Relationship",
                table: "Relatives",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "PaymentMethod",
                table: "Employees",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
