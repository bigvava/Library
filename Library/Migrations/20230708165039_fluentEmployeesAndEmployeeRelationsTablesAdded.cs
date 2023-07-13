using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class fluentEmployeesAndEmployeeRelationsTablesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Fluent_Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Fluent_Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TempId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluent_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fluent_BookEmployee",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluent_BookEmployee", x => new { x.BookId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_Fluent_BookEmployee_Fluent_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Fluent_Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fluent_BookEmployee_Fluent_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Fluent_Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_Users_EmployeeId",
                table: "Fluent_Users",
                column: "EmployeeId",
                unique: true,
                filter: "[EmployeeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_BookEmployee_EmployeeId",
                table: "Fluent_BookEmployee",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_Users_Fluent_Employees_EmployeeId",
                table: "Fluent_Users",
                column: "EmployeeId",
                principalTable: "Fluent_Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_Users_Fluent_Employees_EmployeeId",
                table: "Fluent_Users");

            migrationBuilder.DropTable(
                name: "Fluent_BookEmployee");

            migrationBuilder.DropTable(
                name: "Fluent_Employees");

            migrationBuilder.DropIndex(
                name: "IX_Fluent_Users_EmployeeId",
                table: "Fluent_Users");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Fluent_Users");
        }
    }
}
