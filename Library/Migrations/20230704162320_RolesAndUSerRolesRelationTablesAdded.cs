using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class RolesAndUSerRolesRelationTablesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fluent_Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluent_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fluent_Users_Roles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluent_Users_Roles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_Fluent_Users_Roles_Fluent_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Fluent_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fluent_Users_Roles_Fluent_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Fluent_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_Users_Roles_RoleId",
                table: "Fluent_Users_Roles",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fluent_Users_Roles");

            migrationBuilder.DropTable(
                name: "Fluent_Roles");
        }
    }
}
