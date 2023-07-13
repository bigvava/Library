using Library.DbModels.FluentModels;
using Library.Dtos;
using Library.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FluentBookController : ControllerBase
    {
        private readonly LibraryContext _context;

        public FluentBookController(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet("SearchBooksByAuthorName{authorName}")]
        public async Task<ActionResult<List<Fluent_BookWithDetails>>> Get(string authorName)
        {
            var parameter1 = new SqlParameter("@AuthorName", authorName);

            var booksFromDb = _context.Fluent_BookWithDetails.FromSqlRaw("EXECUTE [dbo].[GetBooksWithDetailsByAuthorName] @AuthorName", parameter1).ToList();
            return booksFromDb;
        }

        [HttpGet]
        [Authorize]
        [RoleFilter("Reader,BookAdder")]
        public async Task<ActionResult<List<GetBookDto>>> Get()
        {
            var currency = await Helper.GetCurrencyByCode("USD");
            var booksFromDb = await _context.Fluent_Books
                .Include(b=>b.BookDetail)
                .ToListAsync();

            List<GetBookDto> resulsts = new List<GetBookDto>();

            foreach (var b in booksFromDb)
            {
                GetBookDto book = new GetBookDto()
                {
                    Id = b.Id,
                    Name = b.Name,
                    PagesCount = b.BookDetail.PagesCount,
                    PriceInGel = $"{(double)b.BookDetail.Price}₾",
                    PriceInUsd = $"{Math.Round((double)b.BookDetail.Price/currency,2)}$"
                };

                resulsts.Add(book);
            }


            return Ok(resulsts);
        }

        [HttpPost]
        [Authorize]
        [RoleFilter("BookAdder")]
        public async Task<ActionResult<List<GetBookDto>>> Post(BookAddDto request)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _context.Fluent_Users.FirstOrDefaultAsync(x => x.Id == int.Parse(userId));
            Fluent_BookDetail detail = new()
            {
                PagesCount = request.PagesCount,
                Price = request.Price
            };

            Fluent_Book newBook = new()
            {
                Name = request.Name,
                AuthorId = request.AuthorId,
                PublisherId = request.PublisherId,
                BookDetail = detail,
                Description = request.Description,
                EmployeeID = user.EmployeeId.Value
            };

            await _context.AddAsync(newBook);
            await _context.SaveChangesAsync();

            var booksObj = _context.Fluent_Books
                .Include(b => b.Publisher)
                .Include(b => b.Author)
                .Include(b => b.BookDetail)
                //.Select(b => new { b.Id, b.Name, b.BookDetail.PagesCount });
                .Select(b => new { b.Id, b.Name, b.BookDetail,b.Publisher,b.Author });

            List<GetBookDto> books = new List<GetBookDto>();
            foreach (var b in booksObj)
            {
                books.Add(
                    new GetBookDto()
                    {
                        Id = (int)b.Id,
                        Name = b.Name,
                        AuthorName = b.Author.FullName,
                        PagesCount = b.BookDetail.PagesCount,
                        PublisherName = b.Publisher.Name
                    }
                    );
            }

            return books;
        }
    }
}
