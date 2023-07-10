using BookAPI.BookAPI.Contracts;
using BookAPI.Models;

namespace BookAPI.Services
{
    public interface IBookService
    {
        void CreateBook(Book book);
        Book GetBook(Guid id);
    }
}
