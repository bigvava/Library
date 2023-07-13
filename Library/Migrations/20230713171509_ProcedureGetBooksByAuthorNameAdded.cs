using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class ProcedureGetBooksByAuthorNameAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp2 = @"CREATE PROCEDURE dbo.GetBooksByAuthorName
                        @AuthorName NVARCHAR(50)
                        AS
                        BEGIN
                        SELECT
	                         B.*
	                        FROM		[Fluent_Authors]		A (NOLOCK)
	                        INNER JOIN	[Fluent_Books]			B (NOLOCK)		ON	A.Id = B.AuthorId
	                        WHERE A.FullName LIKE '%' + @AuthorName + '%'
                        END";
            migrationBuilder.Sql(sp2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE [dbo].[GetBooksByAuthorName]");
        }
    }
}
