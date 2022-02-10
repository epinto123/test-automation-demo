using Microsoft.EntityFrameworkCore;

namespace BookManager.Infrastructure
{
    public class BookManagerDbContext : DbContext
    {
        public BookManagerDbContext(DbContextOptions<BookManagerDbContext> options)
            : base(options) {}

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasKey(book => book.Id);
        }

    }
}
