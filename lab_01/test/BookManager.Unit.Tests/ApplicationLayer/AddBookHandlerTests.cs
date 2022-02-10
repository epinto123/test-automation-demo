using AutoFixture;
using BookManager.ApplicationLayer.Commands.Handlers;
using BookManager.ApplicationLayer.Commands.Interfaces;
using BookManager.ApplicationLayer.Commands.Requests;
using BookManager.ApplicationLayer.Interfaces;
using FluentAssertions;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace BookManager.Unit.Tests.ApplicationLayer
{
    public class AddBookHandlerTests
    {
        private readonly Fixture _fixture;
        private readonly IAddBookHandler _addBookHandler;
        private readonly Mock<IBookRepository> _bookRepository;

        public AddBookHandlerTests()
        {
            _fixture = new Fixture();
            _bookRepository = new Mock<IBookRepository>();
            _addBookHandler = new AddBookHandler(_bookRepository.Object);
        }
        [Fact]
        public async Task InvokesAsync_ReturnsBookId_WhenRequested()
        {
            var addBookRequest = _fixture.Create<AddBookRequest>();
            _bookRepository
                .Setup(x => x.AddBookAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()))
                .ReturnsAsync(_fixture.Create<string>());

            var actualBookId = await _addBookHandler.InvokeAsync(addBookRequest);

            actualBookId.Should().NotBeNull();
        }
    }
}
