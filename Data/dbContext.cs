using library_automation.Models;
using Microsoft.EntityFrameworkCore;
namespace library_automation.Data
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Author> Authors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Loan>().HasOne(m => m.Member).WithMany(lo => lo.Loans).HasForeignKey(m => m.MemberId);
            modelBuilder.Entity<Loan>().HasOne(b => b.Book).WithOne(lo => lo.Loan).HasForeignKey<Loan>(b => b.BookId);
            modelBuilder.Entity<Book>().HasOne(a => a.Author).WithMany(b => b.Books).HasForeignKey(a => a.AuthorId);
            modelBuilder.Entity<Member>().HasData(
                new Member { Id = 1, Name = "John", Email = "john@gmail.com", Phone = "05435436347", Address = "USA" }
            );
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, AuthorId = 1, Title = "Crime and Punishment", Publisher = "DoguBatı", PublicationYear = new DateTime(2010, 1, 1), Genre = "Classic" },
                new Book { Id = 2, AuthorId = 2, Title = "The Great Gatsby", Publisher = "Penguin", PublicationYear = new DateTime(2005, 3, 15), Genre = "Fiction" },
                new Book { Id = 3, AuthorId = 3, Title = "To Kill a Mockingbird", Publisher = "HarperCollins", PublicationYear = new DateTime(2012, 7, 10), Genre = "Classic" },
                new Book { Id = 4, AuthorId = 4, Title = "1984", Publisher = "Vintage", PublicationYear = new DateTime(2009, 5, 20), Genre = "Dystopian" },
                new Book { Id = 5, AuthorId = 5, Title = "Pride and Prejudice", Publisher = "Barnes & Noble", PublicationYear = new DateTime(2018, 11, 5), Genre = "Romance" },
                new Book { Id = 6, AuthorId = 5, Title = "The Catcher in the Rye", Publisher = "Simon & Schuster", PublicationYear = new DateTime(2014, 4, 30), Genre = "Coming of Age" }
            );
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, FirstName = "Jane", LastName = "Austen", Phone = "555-123-4567" },
                new Author { Id = 2, FirstName = "Charles", LastName = "Dickens", Phone = "555-987-6543" },
                new Author { Id = 3, FirstName = "Mark", LastName = "Twain", Phone = "555-555-5555" },
                new Author { Id = 4, FirstName = "Emily", LastName = "Brontë", Phone = "555-246-8101" },
                new Author { Id = 5, FirstName = "Leo", LastName = "Tolstoy", Phone = "555-314-1592" }
            );

            modelBuilder.Entity<Loan>().HasData(
                new Loan { Id = 1, BookId = 1, MemberId = 1, LoanDate = new DateTime(2024, 7, 30), ReturnDate = new DateTime(2024, 7, 31) },
                new Loan { Id = 2, BookId = 2, MemberId = 1, LoanDate = new DateTime(2024, 7, 30), ReturnDate = new DateTime(2024, 7, 31) }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}