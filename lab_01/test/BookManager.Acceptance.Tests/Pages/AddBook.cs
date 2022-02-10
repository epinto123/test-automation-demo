using OpenQA.Selenium;
using BookManager.Acceptance.Tests.Assembly;

namespace BookManager.Acceptance.Tests.Pages
{
    public class AddBook
    {
        public void EnterBookTitle(string bookTile)
        {
            var bookTitleTextBox = By.Id("btitle").RenderElement();
            bookTitleTextBox.SendKeys(bookTile);
        }

        public void EnterAuthorFirstName(string authorFirstName)
        {
            var bookTitleTextBox = By.Id("afirstname").RenderElement();
            bookTitleTextBox.SendKeys(authorFirstName);
        }
        public void EnterAuthorLastName(string authorLastName)
        {
            var bookTitleTextBox = By.Id("alastname").RenderElement();
            bookTitleTextBox.SendKeys(authorLastName);
        }
        public void EnterYearBookWasPublished(string bookYearPublished)
        {
            var bookTitleTextBox = By.Id("byearpublished").RenderElement();
            bookTitleTextBox.Clear();
            bookTitleTextBox.SendKeys(bookYearPublished);
        }
        public void ClickAddBookButton()
        {
            var addButton = By.Id("add-book-button").RenderElement();
            addButton.Click();
        }
    }
}
