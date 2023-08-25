using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data_access.Migrations
{
    public partial class AddAnnotations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishOrder_Orders_OrdersId",
                table: "DishOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Positions_PositionId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Employees_WaiterId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Resumes_Employees_EmployeeId",
                table: "Resumes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Workers");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Orders",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "OrdersId",
                table: "DishOrder",
                newName: "OrdersNumber");

            migrationBuilder.RenameIndex(
                name: "IX_DishOrder_OrdersId",
                table: "DishOrder",
                newName: "IX_DishOrder_OrdersNumber");

            migrationBuilder.RenameColumn(
                name: "Birthdate",
                table: "Workers",
                newName: "DateOfBirth");

            migrationBuilder.RenameColumn(
                name: "PositionId",
                table: "Workers",
                newName: "PositionNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_PositionId",
                table: "Workers",
                newName: "IX_Workers_PositionNumber");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Workers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Workers",
                table: "Workers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DishOrder_Orders_OrdersNumber",
                table: "DishOrder",
                column: "OrdersNumber",
                principalTable: "Orders",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishOrder_Orders_OrdersNumber",
                table: "DishOrder");

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

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Orders",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "OrdersNumber",
                table: "DishOrder",
                newName: "OrdersId");

            migrationBuilder.RenameIndex(
                name: "IX_DishOrder_OrdersNumber",
                table: "DishOrder",
                newName: "IX_DishOrder_OrdersId");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "Employees",
                newName: "Birthdate");

            migrationBuilder.RenameColumn(
                name: "PositionNumber",
                table: "Employees",
                newName: "PositionId");

            migrationBuilder.RenameIndex(
                name: "IX_Workers_PositionNumber",
                table: "Employees",
                newName: "IX_Employees_PositionId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DishOrder_Orders_OrdersId",
                table: "DishOrder",
                column: "OrdersId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Positions_PositionId",
                table: "Employees",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
