namespace BookAPI.BookAPI.Contracts
{
    public record class BookResponse(
        Guid BookId,
        string Title,
        string Description,
        string Publisher,
        int PageCount,
        DateTime LastModifiedDateTime
        );
}
