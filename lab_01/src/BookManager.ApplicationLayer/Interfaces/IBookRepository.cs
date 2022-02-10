using BookManager.ApplicationLayer.Queries.Responses;

namespace BookManager.ApplicationLayer.Interfaces
{
    public interface IBookRepository
    {
        Task<string> AddBookAsync(string title, string authorFirstName, string authorLastName, int yearPublished);
        Task DeleteBookAsync(string id);
        IEnumerable<BookResponse> GetBooks();
    }
}
