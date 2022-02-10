using AutoFixture;
using BookManager.Api.Controllers;
using BookManager.Api.Models;
using BookManager.ApplicationLayer.Commands.Interfaces;
using BookManager.ApplicationLayer.Commands.Requests;
using BookManager.ApplicationLayer.Queries.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace BookManager.Unit.Tests.Controllers
{
    public class BooksControllerTests
    {
        private readonly Books _booksController;
        private readonly Fixture _fixture;
        private readonly Mock<IAddBookHandler> _addBookHandler;
        private readonly Mock<IDeleteBookHandler> _deleteBookHandler;
        private readonly Mock<IGetBooksHandler> _getBooksHandler;

        public BooksControllerTests()
        {
            _fixture = new Fixture();
            _addBookHandler = new Mock<IAddBookHandler>();
            _deleteBookHandler = new Mock<IDeleteBookHandler>();
            _getBooksHandler = new Mock<IGetBooksHandler>();
            _booksController = new Books(_addBookHandler.Object, _deleteBookHandler.Object, _getBooksHandler.Object);
        }

        [Fact]
        public async Task AddsBook_ReturnsCreatedHttpStatus_WhenAddingBook()
        {
            var book = _fixture.Create<Book>();

            var actualResult = (ObjectResult)await _booksController.Add(book);

            actualResult.StatusCode.Should().Be(201);
        }

        [Fact]
        public async Task AddsBook_ReturnsAddedBook_WhenAddingBook()
        {
            var book = _fixture.Create<Book>();
            _addBookHandler
                .Setup(a => a.InvokeAsync(It.IsAny<AddBookRequest>()))
                .ReturnsAsync(_fixture.Create<string>());

            var actualResult = ((ObjectResult) await _booksController.Add(book)).Value;

            var actualBookId = (string?) actualResult?.GetType()?.GetProperty("id")?.GetValue(actualResult);
            actualBookId.Should().NotBeNull();
        }

        [Fact]
        public async Task DeletesBook_ReturnsOkHttpStatus_WhenDeletingBook()
        {
            var bookId = _fixture.Create<string>();

            var actualResult = (OkResult)await _booksController.Delete(bookId);

            actualResult.StatusCode.Should().Be(200);
        }
    }
}