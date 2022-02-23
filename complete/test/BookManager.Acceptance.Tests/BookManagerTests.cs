using AutoFixture;
using BookManager.Acceptance.Tests.Assembly;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading;

namespace BookManager.Acceptance.Tests
{
    public class Tests
    {
        private readonly Context _context;
        public Tests()
        {
            _context = new Context();
        }
        [SetUp]
        public void Setup()
        {
            Browsers.Init(_context.Configuration["driverURL"]);
            Assembly.Pages.Init();
        }

        [Test]
        public void AddingABook_RendersAddedBook_WhenAddingNewBookEntry()
        {
            // setup
            var bookTitle = _context.Fixture.Create<string>();
            var authorFirstName = _context.Fixture.Create<string>();
            var authorLastName = _context.Fixture.Create<string>();
            var yearPublished = _context.Fixture.Create<int>().ToString();

            // act
            Browsers.Goto(_context.Configuration["bookManagerUIUrl"]);
            Assembly.Pages.BookManager.ClickAddBookModalButton();
            Assembly.Pages.AddBook.EnterBookTitle(bookTitle);
            Assembly.Pages.AddBook.EnterAuthorFirstName(authorFirstName);
            Assembly.Pages.AddBook.EnterAuthorLastName(authorLastName);
            Assembly.Pages.AddBook.EnterYearBookWasPublished(yearPublished);
            Assembly.Pages.AddBook.ClickAddBookButton();

            Thread.Sleep(TimeSpan.FromSeconds(5));

            // assert
            var addedBook = Assembly.Pages.Book.GetLastAddedBook();
            var expectedAddedBook = $"{bookTitle} {authorFirstName} {authorLastName} {yearPublished}";
            addedBook.Should().Be(expectedAddedBook);
        }

        [Test]
        public void DeletingABook_BookGetsDeleted_WhenDeletingBookEntry()
        {
            // setup
            Browsers.Goto(_context.Configuration["bookManagerUIUrl"]);
            _context.AddBook();
            var addedBookToDelete = _context.AddBook();
            
            // act
            Assembly.Pages.Book.DeleteLastAddedBook();

            Thread.Sleep(TimeSpan.FromSeconds(5));

            // assert
            var allAddedBooks = Assembly.Pages.Book.GetAllAddedBooks().Select(addedBook => addedBook.Text).ToList();
            var deletedBook = addedBookToDelete;
            allAddedBooks.Should().NotContain(deletedBook);
        }

        [TearDown]
        public void TearDown()
        {
            Browsers.Close();
        }
    }
}
