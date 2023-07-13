using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class StoredProceduresMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp2 = @"CREATE PROCEDURE dbo.GetBooksWithDetailsByAuthorName
                        @AuthorName NVARCHAR(50)
                        AS
                        BEGIN
                        SELECT
	                         B.Id, B.Name, B.Description, BD.PagesCount, BD.Price
	                        FROM		[Fluent_Authors]		A (NOLOCK)
	                        INNER JOIN	[Fluent_Books]			B (NOLOCK)		ON	A.Id = B.AuthorId
	                        LEFT JOIN	[Fluent_BookDetails]	BD (NOLOCK)		ON	BD.BookId = B.Id
	                        WHERE A.FullName LIKE '%' + @AuthorName + '%'
                        END";
            migrationBuilder.Sql(sp2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE [dbo].[GetBooksWithDetailsByAuthorName]");
        }
    }
}
