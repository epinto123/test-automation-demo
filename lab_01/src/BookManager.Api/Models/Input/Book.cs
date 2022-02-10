namespace BookManager.Api.Models
{
    public class Book
    {
        public string Title { get; set; }

        public Person AuthorName { get; set; }

        public int YearPublished { get; set; }
    }
}
