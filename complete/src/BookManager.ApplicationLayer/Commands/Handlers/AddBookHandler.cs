using BookManager.ApplicationLayer.Commands.Interfaces;
using BookManager.ApplicationLayer.Commands.Requests;
using BookManager.ApplicationLayer.Interfaces;

namespace BookManager.ApplicationLayer.Commands.Handlers
{
    public class AddBookHandler : IAddBookHandler
    {
        private readonly IBookRepository _bookRepository;

        public AddBookHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<string> InvokeAsync(AddBookRequest addBookRequest)
        {
            return await _bookRepository.AddBookAsync(
                addBookRequest.Title,
                addBookRequest.AuthorFirstName,
                addBookRequest.AuthorLastName,
                addBookRequest.YearPublished);
        }
    }
}
