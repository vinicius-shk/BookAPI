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

            var response = new BookResponse(
                book.Id,
                book.Title,
                book.Description,
                book.Publisher,
                book.PageCount,
                book.LastModifiedDateTime
                );
            return CreatedAtAction(
                nameof( CreateBook ),
                new { id = book.Id },
                response);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetBook(Guid id)
        {
            Book book = _bookService.GetBook(id);

            var response = new BookResponse(
                book.Id,
                book.Title,
                book.Description,
                book.Publisher,
                book.PageCount,
                book.LastModifiedDateTime
                );

            return Ok(response);
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpsertBook(Guid id, UpsertBookRequest request)
        {
            return Ok(request);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeletetBook(Guid id)
        {
            return NoContent();
        }
    }
}
