namespace BookManager.Api.Models.Output
{
    public class Book
    {
        public string Id { get; set; }
        public string Title { get; set; }

        public Person AuthorName { get; set; }

        public int YearPublished { get; set; }
    }
}
