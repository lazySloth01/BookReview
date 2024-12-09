using Microsoft.EntityFrameworkCore;
using BookReview.Models;

/// Represents the database context for the BookReview application.
public class BookReviewContext : DbContext
{
    /// Initializes a new instance of the <see cref="BookReviewContext"/> class.
    /// <param name="options">The options to be used by the DbContext.</param>
    public BookReviewContext(DbContextOptions<BookReviewContext> options)
        : base(options)
    {
    }

    /// Gets or sets the DbSet of books.
    public DbSet<Book> Books { get; set; }

    /// Gets or sets the DbSet of reviews.
    public DbSet<Review> Reviews { get; set; }


}
