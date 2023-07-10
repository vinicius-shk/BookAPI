using BookAPI.BookAPI.Contracts;
using BookAPI.Models;

namespace BookAPI.Services
{
    public interface IBookService
    {
        void CreateBook(Book book);
        void DeleteBook(Guid id);
        Book GetBook(Guid id);
        void UpsertBook(Book book);
    }
}
