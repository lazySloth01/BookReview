using System.ComponentModel.DataAnnotations;

namespace BookReview.Models
{
    /// Represents a review for a book.
    public class Review
    {
        /// Gets or sets the unique identifier for the review.
        public int Id { get; set; } // Auto-incremented primary key

        /// Gets or sets the foreign key to the Book table.
        public int BookId { get; set; } 

        /// Gets or sets the rating for the book.
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Rating { get; set; }

        /// Gets or sets the comment for the review.
        public string? Comment { get; set; }

        /// Navigation property for the related book
        public Book? Book { get; set; } 
    }
}
