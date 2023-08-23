using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _01_intro_to_ef.Migrations
{
    public partial class UseFluentAPI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Workers_WaiterId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Resumes_Workers_EmployeeId",
                table: "Resumes");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Positions_PositionNumber",
                table: "Workers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Workers",
                table: "Workers");

            migrationBuilder.RenameTable(
                name: "Workers",
                newName: "Employees");

            migrationBuilder.RenameIndex(
                name: "IX_Workers_PositionNumber",
                table: "Employees",
                newName: "IX_Employees_PositionNumber");

            migrationBuilder.AddPrimaryKey(
                name: "Workers",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Positions_PositionNumber",
                table: "Employees",
                column: "PositionNumber",
                principalTable: "Positions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Employees_WaiterId",
                table: "Orders",
                column: "WaiterId",
                principalTable: "Employees",
                principalColumn: "Id");

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
                name: "FK_Employees_Positions_PositionNumber",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Employees_WaiterId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Resumes_Employees_EmployeeId",
                table: "Resumes");

            migrationBuilder.DropPrimaryKey(
                name: "Workers",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Workers");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_PositionNumber",
                table: "Workers",
                newName: "IX_Workers_PositionNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Workers",
                table: "Workers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Workers_WaiterId",
                table: "Orders",
                column: "WaiterId",
                principalTable: "Workers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Resumes_Workers_EmployeeId",
                table: "Resumes",
                column: "EmployeeId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Positions_PositionNumber",
                table: "Workers",
                column: "PositionNumber",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
