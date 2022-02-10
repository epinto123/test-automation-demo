using BookManager.ApplicationLayer.Interfaces;
using BookManager.ApplicationLayer.Queries.Interfaces;
using BookManager.ApplicationLayer.Queries.Responses;

namespace BookManager.ApplicationLayer.Queries.Handlers
{
    public class GetBooksHandler : IGetBooksHandler
    {
        private readonly IBookRepository _bookRepository;

        public GetBooksHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public Task<IEnumerable<BookResponse>> InvokeAsync()
        {
            return Task.FromResult(_bookRepository.GetBooks());
        }
    }
}
