using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeLogicalMistakeSolved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fluent_BookEmployee");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeID",
                table: "Fluent_Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_Books_EmployeeID",
                table: "Fluent_Books",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_Books_Fluent_Employees_EmployeeID",
                table: "Fluent_Books",
                column: "EmployeeID",
                principalTable: "Fluent_Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_Books_Fluent_Employees_EmployeeID",
                table: "Fluent_Books");

            migrationBuilder.DropIndex(
                name: "IX_Fluent_Books_EmployeeID",
                table: "Fluent_Books");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "Fluent_Books");

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
                name: "IX_Fluent_BookEmployee_EmployeeId",
                table: "Fluent_BookEmployee",
                column: "EmployeeId");
        }
    }
}
