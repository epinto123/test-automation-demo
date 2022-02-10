using BookManager.ApplicationLayer.Queries.Responses;

namespace BookManager.ApplicationLayer.Queries.Interfaces
{
    public interface IGetBooksHandler
    {
        Task<IEnumerable<BookResponse>> InvokeAsync();
    }
}
