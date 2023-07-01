using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class RelationBetweenAuthorAndBooksAddedOneToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Fluent_Books_AuthorId",
                table: "Fluent_Books",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_Books_Fluent_Authors_AuthorId",
                table: "Fluent_Books",
                column: "AuthorId",
                principalTable: "Fluent_Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_Books_Fluent_Authors_AuthorId",
                table: "Fluent_Books");

            migrationBuilder.DropIndex(
                name: "IX_Fluent_Books_AuthorId",
                table: "Fluent_Books");
        }
    }
}
