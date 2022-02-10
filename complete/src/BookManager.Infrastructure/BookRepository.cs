using BookManager.ApplicationLayer.Interfaces;
using BookManager.ApplicationLayer.Queries.Responses;

namespace BookManager.Infrastructure
{
    public class BookRepository : IBookRepository
    {
        private readonly BookManagerDbContext _context;

        public BookRepository(BookManagerDbContext context)
        {
            _context = context;
        }
        public async Task<string> AddBookAsync(string title, string authorFirstName, string authorLastName, int yearPublished)
        {
            var book = new Book()
            {
                Id = Guid.NewGuid().ToString(),
                Title = title,
                AuthorFirstName = authorFirstName,
                AuthorLastName = authorLastName,
                YearPublished = yearPublished
            };
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

            return book.Id;
        }

        public async Task DeleteBookAsync(string id)
        {
            var book = _context.Books.Where(book => book.Id == id).FirstOrDefault();
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<BookResponse> GetBooks()
        {
            var books = _context.Books.ToList();
            return books.Select(book => new BookResponse
            {
                Id = book.Id,
                Title = book.Title,
                AuthorFirstName = book.AuthorFirstName,
                AuthorLastName = book.AuthorLastName,
                YearPublished = book.YearPublished
            });
        }
    }
}
