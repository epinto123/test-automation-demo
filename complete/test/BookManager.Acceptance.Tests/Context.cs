using AutoFixture;
using Microsoft.Extensions.Configuration;
using BookManager.Acceptance.Tests.Assembly;
using BookManager.Acceptance.Tests.Pages;
using System.Threading.Tasks;
using System;
using NUnit.Framework;

public class Context
{
    private readonly IConfiguration _configuration;
    private readonly Fixture _fixture;

    public Context()
    {
        _configuration = new ConfigurationBuilder().AddJsonFile("config.json").Build();
        _fixture = new Fixture();
        _fixture.Customizations.Add(new RandomNumericSequenceGenerator(1200, 2040));
    }

    public string AddBook()
    {
        var bookTitle = Fixture.Create<string>();
        var authorFirstName = Fixture.Create<string>();
        var authorLastName = Fixture.Create<string>();
        var yearPublished = Fixture.Create<int>().ToString();

        Pages.BookManager.ClickAddBookModalButton();
        Pages.AddBook.EnterBookTitle(bookTitle);
        Pages.AddBook.EnterAuthorFirstName(authorFirstName);
        Pages.AddBook.EnterAuthorLastName(authorLastName);
        Pages.AddBook.EnterYearBookWasPublished(yearPublished);
        Pages.AddBook.ClickAddBookButton();

        return $"{bookTitle} {authorFirstName} {authorLastName} {yearPublished}";
    }

    public async Task ClearAllBooksAsync()
    {
        try
        {
            var book = new Book();
            var bookIds = book.GetAllAddedBookIds();

            using (var httpClient = new System.Net.Http.HttpClient())
            {
                foreach (var bookId in bookIds)
                {
                    await httpClient.DeleteAsync($"{_configuration["bookManagerApi"]}/api/books/{bookId}");
                }
            }
        }
        catch(Exception ex)
        {
            TestContext.WriteLine("Books could not be cleaned up", ex);
        }
    }

    public IConfiguration Configuration => _configuration;
    public Fixture Fixture => _fixture;
}
