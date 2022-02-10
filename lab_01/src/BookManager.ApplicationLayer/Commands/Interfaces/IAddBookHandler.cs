namespace BookManager.ApplicationLayer.Commands.Interfaces
{
    public interface IAddBookHandler
    {
        Task<string> InvokeAsync(Requests.AddBookRequest addBookRequest);
    }
}
