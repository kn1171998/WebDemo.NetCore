using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PayComputePersistence.Migrations
{
    public partial class db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
             name: "LocationEmployees",
             columns: table => new
             {
                 LocationId = table.Column<int>(nullable: false),
                 EmployeeId = table.Column<int>(nullable: false),
                 EmployeeLocation = table.Column<int>(nullable: true),
                 LocationEmployee = table.Column<int>(nullable: true)
             },
             constraints: table =>
             {
                 table.PrimaryKey("PK_LocationEmployees", x => new { x.EmployeeId, x.LocationId });
                 table.ForeignKey(
                     name: "FK_LocationEmployees_Employees_EmployeeLocation",
                     column: x => x.EmployeeLocation,
                     principalTable: "Employees",
                     principalColumn: "Id",
                     onDelete: ReferentialAction.Restrict);
                 table.ForeignKey(
                     name: "FK_LocationEmployees_Locations_LocationEmployee",
                     column: x => x.LocationEmployee,
                     principalTable: "Locations",
                     principalColumn: "Id",
                     onDelete: ReferentialAction.Restrict);
             });
            migrationBuilder.CreateIndex(
              name: "IX_LocationEmployees_EmployeeLocation",
              table: "LocationEmployees",
              column: "EmployeeLocation");

            migrationBuilder.CreateIndex(
                name: "IX_LocationEmployees_LocationEmployee",
                table: "LocationEmployees",
                column: "LocationEmployee");
            migrationBuilder.DropForeignKey(
                name: "FK_LocationEmployees_Employees_EmployeeLocation",
                table: "LocationEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationEmployees_Locations_LocationEmployee",
                table: "LocationEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_PositionJobs_PositionJobId",
                table: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocationEmployees",
                table: "LocationEmployees");

            migrationBuilder.DropIndex(
                name: "IX_LocationEmployees_EmployeeLocation",
                table: "LocationEmployees");

            migrationBuilder.DropIndex(
                name: "IX_LocationEmployees_LocationEmployee",
                table: "LocationEmployees");

            migrationBuilder.DropColumn(
                name: "DateJoinedLocation",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "EmployeeLocation",
                table: "LocationEmployees");

            migrationBuilder.DropColumn(
                name: "LocationEmployee",
                table: "LocationEmployees");

            migrationBuilder.AlterColumn<int>(
                name: "PositionJobId",
                table: "Locations",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateJoinedLocation",
                table: "LocationEmployees",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocationEmployees",
                table: "LocationEmployees",
                column: "DateJoinedLocation");

            migrationBuilder.CreateIndex(
                name: "IX_LocationEmployees_EmployeeId",
                table: "LocationEmployees",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationEmployees_LocationId",
                table: "LocationEmployees",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_LocationEmployees_Employees_EmployeeId",
                table: "LocationEmployees",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationEmployees_Locations_LocationId",
                table: "LocationEmployees",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_PositionJobs_PositionJobId",
                table: "Locations",
                column: "PositionJobId",
                principalTable: "PositionJobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocationEmployees_Employees_EmployeeId",
                table: "LocationEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationEmployees_Locations_LocationId",
                table: "LocationEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_PositionJobs_PositionJobId",
                table: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocationEmployees",
                table: "LocationEmployees");

            migrationBuilder.DropIndex(
                name: "IX_LocationEmployees_EmployeeId",
                table: "LocationEmployees");

            migrationBuilder.DropIndex(
                name: "IX_LocationEmployees_LocationId",
                table: "LocationEmployees");

            migrationBuilder.DropColumn(
                name: "DateJoinedLocation",
                table: "LocationEmployees");

            migrationBuilder.AlterColumn<int>(
                name: "PositionJobId",
                table: "Locations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateJoinedLocation",
                table: "Locations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "Locations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeLocation",
                table: "LocationEmployees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationEmployee",
                table: "LocationEmployees",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocationEmployees",
                table: "LocationEmployees",
                columns: new[] { "EmployeeId", "LocationId" });

            migrationBuilder.CreateIndex(
                name: "IX_LocationEmployees_EmployeeLocation",
                table: "LocationEmployees",
                column: "EmployeeLocation");

            migrationBuilder.CreateIndex(
                name: "IX_LocationEmployees_LocationEmployee",
                table: "LocationEmployees",
                column: "LocationEmployee");

            migrationBuilder.AddForeignKey(
                name: "FK_LocationEmployees_Employees_EmployeeLocation",
                table: "LocationEmployees",
                column: "EmployeeLocation",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationEmployees_Locations_LocationEmployee",
                table: "LocationEmployees",
                column: "LocationEmployee",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_PositionJobs_PositionJobId",
                table: "Locations",
                column: "PositionJobId",
                principalTable: "PositionJobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
