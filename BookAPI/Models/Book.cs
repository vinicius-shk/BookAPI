namespace BookAPI.Models
{
    public class Book
    {
        public Guid Id { get; }
        public string Title { get; }
        public string Description { get; }
        public string Publisher { get; }
        public int PageCount { get; }
        public DateTime LastModifiedDateTime { get; }

        public Book(
            Guid id,
            string title,
            string description,
            string publisher,
            int pageCount,
            DateTime lastModifiedDateTime
            )
        {
            Id = id;
            PageCount = pageCount;
            Title = title;
            Description = description;
            Publisher = publisher;
            LastModifiedDateTime = lastModifiedDateTime;
        }
    }
}
