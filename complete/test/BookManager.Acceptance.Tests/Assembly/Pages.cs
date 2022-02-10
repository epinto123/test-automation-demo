namespace BookManager.Acceptance.Tests.Assembly
{
    public static class Pages
    {
        public static Acceptance.Tests.Pages.BookManager BookManager;
        public static Acceptance.Tests.Pages.Book Book;
        public static Acceptance.Tests.Pages.AddBook AddBook;

        public static void Init()
        {
            BookManager = new Acceptance.Tests.Pages.BookManager();
            Book = new Acceptance.Tests.Pages.Book();
            AddBook = new Acceptance.Tests.Pages.AddBook();
        }
    }
}
