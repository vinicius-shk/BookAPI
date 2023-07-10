namespace BookAPI.BookAPI.Contracts
{
    public record class UpsertBookRequest(
        string Title,
        string Description,
        string Publisher,
        int PageCount
    );
}
