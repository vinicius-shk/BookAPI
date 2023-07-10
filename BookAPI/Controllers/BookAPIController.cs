using BookAPI.BookAPI.Contracts;
using BookAPI.Models;
using BookAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [ApiController]
    [Route("/book")]
    public class BookAPIController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookAPIController(IBookService bookService)
        {
            _bookService = bookService;
        }

        private static BookResponse MapBookResponse(Book book)
        {
            return new BookResponse(
                            book.Id,
                            book.Title,
                            book.Description,
                            book.Publisher,
                            book.PageCount,
                            book.LastModifiedDateTime
                            );
        }

        [HttpPost]
        public IActionResult CreateBook(CreateBookRequest request)
        {
            var book = new Book(
                Guid.NewGuid(),
                request.Title,
                request.Description,
                request.Publisher,
                request.PageCount,
                DateTime.UtcNow);

            // TODO: save to db
            _bookService.CreateBook(book);

            BookResponse response = MapBookResponse(book);
            return CreatedAtAction(
                nameof( CreateBook ),
                new { id = response.BookId },
                response);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetBook(Guid id)
        {
            Book? book = _bookService.GetBook(id);

            if (book == null)
            {
                return NotFound();
            }

            BookResponse response = MapBookResponse(book);

            return Ok(response);
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpsertBook(Guid id, UpsertBookRequest request)
        {
            var book = new Book(
                id,
                request.Title,
                request.Description,
                request.Publisher,
                request.PageCount,
                DateTime.UtcNow);

            if (_bookService.GetBook(id) == null)
            {
                BookResponse response = MapBookResponse(book);
                _bookService.UpsertBook(book);
                return CreatedAtAction(
                    nameof( CreateBook ),
                    new { id = book.Id },
                    response);
            }

            _bookService.UpsertBook(book);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeletetBook(Guid id)
        {
            _bookService.DeleteBook(id);
            return NoContent();
        }
    }
}
