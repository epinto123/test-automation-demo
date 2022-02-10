namespace BookManager.ApplicationLayer.Commands.Requests
{
    public class AddBookRequest
    {
        public string Title { get; set; }

        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }

        public int YearPublished { get; set; }
    }
}
