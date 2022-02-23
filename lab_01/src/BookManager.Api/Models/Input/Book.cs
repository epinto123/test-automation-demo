namespace BookManager.Api.Models.Input
{
    public class Book
    {
        public string Title { get; set; }

        public Person AuthorName { get; set; }

        public int YearPublished { get; set; }
    }
}
