namespace BookAPI.BookAPI.Contracts
{
    public record CreateBookRequest(
        string Title,
        string Description,
        string Publisher,
        int PageCount
    );
}
