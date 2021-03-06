namespace BookManager.Infrastructure
{
    public class Book
    {
        public string Title { get; set; }

        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }

        public int YearPublished { get; set; }
        public string Id { get; set; }
    }
}
