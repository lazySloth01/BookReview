namespace BookReview.Models
{
    /// Represents a book.
    public class Book
    {
        /// Gets or sets the unique identifier for the book.
        public int Id { get; set; } 

        /// Gets or sets the title of the book.
        public string Title { get; set; } 

        /// Gets or sets the author of the book.
        public string Author { get; set; } 

        /// Gets or sets the reviews for the book.
        public List<Review>? Reviews { get; set; }
    }
}
