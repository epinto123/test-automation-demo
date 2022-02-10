using BookManager.ApplicationLayer.Commands.Interfaces;
using BookManager.ApplicationLayer.Interfaces;

namespace BookManager.ApplicationLayer.Commands.Handlers
{
    public class DeleteBookHandler : IDeleteBookHandler
    {
        private readonly IBookRepository _bookRepository;

        public DeleteBookHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task InvokeAsync(string id)
        {
            await _bookRepository.DeleteBookAsync(id);
        }
    }
}
