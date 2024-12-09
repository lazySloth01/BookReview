using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class TestController : Controller
{
    private readonly BookReviewContext _context;

    public TestController(BookReviewContext context)
    {
        _context = context;
    }

    [HttpGet("test-connection")]
    public async Task<IActionResult> TestConnection()
    {
        try
        {
            // Attempt to query the Books table (this assumes you have a Books table)
            var books = await _context.Books.ToListAsync();

            // If successful, return the number of books
            return Ok($"Connection successful. Number of books: {books.Count}");
        }
        catch (Exception ex)
        {
            // If there is an error, return the error message
            return BadRequest($"Connection failed: {ex.Message}");
        }
    }
}