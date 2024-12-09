using BookReview.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly BookReviewContext _context;

    public BooksController(BookReviewContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> AddBook([FromBody] Book book)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> GetBook(int id)
    {
        var book = await _context.Books.Include(b => b.Reviews).FirstOrDefaultAsync(b => b.Id == id);
        if (book == null)
        {
            return NotFound();
        }
        return book;
    }
}