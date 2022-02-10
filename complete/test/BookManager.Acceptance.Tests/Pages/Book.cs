using OpenQA.Selenium;
using BookManager.Acceptance.Tests.Assembly;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BookManager.Acceptance.Tests.Pages
{
    public class Book
    {
        public void DeleteLastAddedBook()
        {
            var deleteButton = By.XPath("(//tbody/tr)[last()]/*//button[@id='delete-book-button']").RenderElement();
            deleteButton.Click();
        }

        public string GetLastAddedBook()
        {
            var tableRow = By.XPath("(//tbody/tr)[last()]").RenderElement();

            return tableRow.Text;
        }

        public IReadOnlyCollection<IWebElement> GetAllAddedBooks()
        {
            var tableRows = By.XPath("//tbody/tr").RenderElements();

            return tableRows;
        }
    }
}
