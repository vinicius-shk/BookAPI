using BookAPI.Models;

namespace BookAPI.Services
{
    public class BookService : IBookService
    {
        private static readonly Dictionary<Guid, Book> _books = new();
        public void CreateBook(Book book)
        {
            _books.Add(book.Id, book);
        }

        public void DeleteBook(Guid id)
        {
            _books.Remove(id);
        }

        public Book? GetBook(Guid id)
        {   
            if (_books.ContainsKey(id))
            {
            return _books[id];
            }
            return null;
        }

        public void UpsertBook(Book book)
        {
            _books[book.Id] = book;
        }
    }
}
