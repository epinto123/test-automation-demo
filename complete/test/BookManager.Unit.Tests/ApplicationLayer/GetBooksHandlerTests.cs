using AutoFixture;
using BookManager.ApplicationLayer.Interfaces;
using BookManager.ApplicationLayer.Queries.Handlers;
using BookManager.ApplicationLayer.Queries.Interfaces;
using BookManager.ApplicationLayer.Queries.Responses;
using FluentAssertions;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace BookManager.Unit.Tests.ApplicationLayer
{
    public class GetBooksHandlerTests
    {
        private readonly Fixture _fixture;
        private readonly IGetBooksHandler _getBooksHandler;
        private readonly Mock<IBookRepository> _bookRepository;

        public GetBooksHandlerTests()
        {
            _fixture = new Fixture();
            _bookRepository = new Mock<IBookRepository>();
            _getBooksHandler = new GetBooksHandler(_bookRepository.Object);
        }
        [Fact]
        public async Task InvokesAsync_ReturnsMultipleBooks_WhenRequested()
        {
            _bookRepository
                .Setup(x => x.GetBooks())
                .Returns(_fixture.CreateMany<BookResponse>());

            var actualBooks = await _getBooksHandler.InvokeAsync();

            actualBooks.Should().HaveCountGreaterThan(0);
        }
    }
}
