using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data_access.Migrations
{
    public partial class SeedResume : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resume_Employees_EmployeeId",
                table: "Resume");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Resume",
                table: "Resume");

            migrationBuilder.RenameTable(
                name: "Resume",
                newName: "Resumes");

            migrationBuilder.RenameIndex(
                name: "IX_Resume_EmployeeId",
                table: "Resumes",
                newName: "IX_Resumes_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resumes",
                table: "Resumes",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Birthdate", "Name", "PositionId", "Salary", "Surname" },
                values: new object[] { 1, new DateTime(1988, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrii", 2, 1200m, "Povar" });

            migrationBuilder.InsertData(
                table: "Resumes",
                columns: new[] { "Id", "Certified", "Description", "EmployeeId", "Experience", "Summary" },
                values: new object[] { 1, true, null, 1, 2, "I am a great cook!" });

            migrationBuilder.AddForeignKey(
                name: "FK_Resumes_Employees_EmployeeId",
                table: "Resumes",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resumes_Employees_EmployeeId",
                table: "Resumes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Resumes",
                table: "Resumes");

            migrationBuilder.DeleteData(
                table: "Resumes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "Resumes",
                newName: "Resume");

            migrationBuilder.RenameIndex(
                name: "IX_Resumes_EmployeeId",
                table: "Resume",
                newName: "IX_Resume_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resume",
                table: "Resume",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Resume_Employees_EmployeeId",
                table: "Resume",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
