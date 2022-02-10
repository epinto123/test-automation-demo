using OpenQA.Selenium;
using BookManager.Acceptance.Tests.Assembly;

namespace BookManager.Acceptance.Tests.Pages
{
    public class BookManager
    {
        public void ClickAddBookModalButton()
        {
            var requestRow = By.Id("add-book").RenderElement();
            requestRow.Click();
        }
    }
}
