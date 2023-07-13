using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class fluentUserTableForeignKeyReaderIdBecameNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_Users_Fluent_Readers_ReaderId",
                table: "Fluent_Users");

            migrationBuilder.DropIndex(
                name: "IX_Fluent_Users_ReaderId",
                table: "Fluent_Users");

            migrationBuilder.AlterColumn<int>(
                name: "ReaderId",
                table: "Fluent_Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_Users_ReaderId",
                table: "Fluent_Users",
                column: "ReaderId",
                unique: true,
                filter: "[ReaderId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_Users_Fluent_Readers_ReaderId",
                table: "Fluent_Users",
                column: "ReaderId",
                principalTable: "Fluent_Readers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_Users_Fluent_Readers_ReaderId",
                table: "Fluent_Users");

            migrationBuilder.DropIndex(
                name: "IX_Fluent_Users_ReaderId",
                table: "Fluent_Users");

            migrationBuilder.AlterColumn<int>(
                name: "ReaderId",
                table: "Fluent_Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_Users_ReaderId",
                table: "Fluent_Users",
                column: "ReaderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_Users_Fluent_Readers_ReaderId",
                table: "Fluent_Users",
                column: "ReaderId",
                principalTable: "Fluent_Readers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
