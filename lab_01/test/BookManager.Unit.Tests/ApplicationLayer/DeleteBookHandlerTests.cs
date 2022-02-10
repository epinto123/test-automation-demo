using AutoFixture;
using BookManager.ApplicationLayer.Commands.Handlers;
using BookManager.ApplicationLayer.Commands.Interfaces;
using BookManager.ApplicationLayer.Interfaces;
using FluentAssertions;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace BookManager.Unit.Tests.ApplicationLayer
{
    public class DeleteBookHandlerTests
    {
        private readonly Fixture _fixture;
        private readonly IDeleteBookHandler _deleteBookHandler;
        private readonly Mock<IBookRepository> _bookRepository;

        public DeleteBookHandlerTests()
        {
            _fixture = new Fixture();
            _bookRepository = new Mock<IBookRepository>();
            _deleteBookHandler = new DeleteBookHandler(_bookRepository.Object);
        }
        [Fact]
        public void InvokesAsync_DoesNotThrowAnyExceptions_WhenRequested()
        {
            var bookId = _fixture.Create<string>();
            _bookRepository
                .Setup(x => x.DeleteBookAsync(It.IsAny<string>()));

            Func<Task> act = () => _deleteBookHandler.InvokeAsync(bookId);

            act.Should().NotThrowAsync<Exception>();
        }
    }
}
