namespace BookManager.ApplicationLayer.Commands.Interfaces
{
    public interface IDeleteBookHandler
    {
        Task InvokeAsync(string id);
    }
}
