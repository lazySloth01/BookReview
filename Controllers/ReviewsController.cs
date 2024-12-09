using BookReview.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/reviews")]
public class ReviewsController : ControllerBase
{
    private readonly BookReviewContext _context;

    public ReviewsController(BookReviewContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> AddReview([FromBody] Review review)
    {
        if (review == null || review.BookId == 0)
        {
            return BadRequest("Invalid review data.");
        }

        var book = await _context.Books.FindAsync(review.BookId);
        if (book == null)
        {
            return NotFound("Book not found.");
        }

        _context.Reviews.Add(review);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetReview), new { id = review.Id }, review);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Review>> GetReview(int id)
    {
        var review = await _context.Reviews.FirstOrDefaultAsync(r => r.Id == id);
        if (review == null)
        {
            return NotFound();
        }
        return review;
    }
}
