using BookManager.Api.Models;
using BookManager.Api.Models.Input;
using BookManager.ApplicationLayer.Commands.Interfaces;
using BookManager.ApplicationLayer.Commands.Requests;
using BookManager.ApplicationLayer.Queries.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Api.Controllers
{
    [ApiController]
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    public class Books : ControllerBase
    {
        private readonly IAddBookHandler _addBookHandler;
        private readonly IDeleteBookHandler _deleteBookHandler;
        private readonly IGetBooksHandler _getBooksHandler;

        public Books(
            IAddBookHandler addBookHandler,
            IDeleteBookHandler deleteBookHandler,
            IGetBooksHandler getBooksHandler)
        {
            _addBookHandler = addBookHandler;
            _deleteBookHandler = deleteBookHandler;
            _getBooksHandler = getBooksHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var booksResponse = await _getBooksHandler.InvokeAsync();

            var books = booksResponse
                .Select(bookResponse => new Models.Output.Book
                {
                    AuthorName = new Person
                    {
                        FirstName = bookResponse.AuthorFirstName,
                        LastName = bookResponse.AuthorLastName,
                    },
                    Title = bookResponse.Title,
                    YearPublished = bookResponse.YearPublished,
                    Id = bookResponse.Id
                });

            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Book book)
        {
            var addBookRequest = new AddBookRequest
            {
                AuthorFirstName = book.AuthorName.FirstName,
                AuthorLastName = book.AuthorName.LastName,
                Title = book.Title,
                YearPublished = book.YearPublished
            };
            var bookId = await _addBookHandler.InvokeAsync(addBookRequest);

            return Created("~api/books", new { id = bookId });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _deleteBookHandler.InvokeAsync(id);

            return Ok();
        }
    }
}
