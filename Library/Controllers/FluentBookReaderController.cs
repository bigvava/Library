using Library.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FluentBookReaderController : ControllerBase
    {
        private readonly LibraryContext _context;

        public FluentBookReaderController(LibraryContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Fluent_BookReader>>> Get()
        {
            var result = from br in _context.Fluent_BookReaders
                         join book in _context.Fluent_Books on br.BookId equals book.Id
                         join reader in _context.Fluent_Readers on br.ReaderId equals reader.Id
                         select new { book, reader };
            
            return Ok(result);
        }

        [Route("Search")]
        [HttpGet]
        public async Task<ActionResult<List<Fluent_BookReader>>> Get(string ReaderName, string BookName)
        {
            //var result = from br in _context.Fluent_BookReaders
            //             join book in _context.Fluent_Books on br.BookId equals book.Id
            //             join reader in _context.Fluent_Readers on br.ReaderId equals reader.Id
            //             where
            //             (string.IsNullOrEmpty(BookName) || book.Name.Contains(BookName))
            //             &&
            //             (string.IsNullOrEmpty(ReaderName) || reader.FirstName.Contains(ReaderName))
            //             select new { book, reader };


            //ShowReminder
            //var querry = from br in _context.Fluent_BookReaders
            //             join book in _context.Fluent_Books on br.BookId equals book.Id
            //             join reader in _context.Fluent_Readers on br.ReaderId equals reader.Id
            //             select new { book, reader };

            //if (!string.IsNullOrEmpty(ReaderName))
            //{
            //    querry = querry.Where(x => x.reader.FirstName.Contains(ReaderName));
            //}

            //if (!string.IsNullOrEmpty(BookName))
            //{
            //    querry = querry.Where(x => x.book.Name.Contains(BookName));
            //}





            var lambdaQuerry = _context.Fluent_BookReaders
                                .Include(x => x.Reader)
                                .Include(x => x.Book)
                                .Select(br => new { br.Reader, br.Book });

            if (!string.IsNullOrEmpty(ReaderName))
            {
                lambdaQuerry = lambdaQuerry.Where(x => x.Reader.FirstName.Contains(ReaderName));
            }

            if (!string.IsNullOrEmpty(BookName))
            {
                lambdaQuerry = lambdaQuerry.Where(x => x.Book.Name.Contains(BookName));
            }


            return Ok(lambdaQuerry);
        }

        [HttpPost]
        public async Task<ActionResult<List<Fluent_BookReader>>> Post(AddBookReaderDto request)
        {
            var bookReader = new Fluent_BookReader()
            {
                BookId = request.BookId,
                ReaderId = request.ReaderId
            };

            await _context.AddAsync(bookReader);
            await _context.SaveChangesAsync();



            var bookReaders = _context.Fluent_BookReaders
                .Include(x => x.Book)
                .Include(x => x.Reader)
                .Select(br => new
                {
                    Fluent_Book = new
                    {
                        br.Book.Id,
                        br.Book.Name,
                        br.Book.Description,

                        BookDetail = new
                        {
                            br.Book.BookDetail.Id,
                            br.Book.BookDetail.PagesCount,
                            br.Book.BookDetail.Price
                        }
                    },
                    Fluent_Reader = new
                    {
                        br.Reader.Id,
                        br.Reader.FirstName,
                        br.Reader.LastName,
                        br.Reader.PhoneNumber
                    }
                }).ToList();




            return Ok(bookReaders);
        }
    }
}
