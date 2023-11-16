using LibrarySystem.Common.Books;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookDto>>> GetAll()
    {
        return Ok(new List<BookDto>());
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<BookDto>> GetById(int id)
    {
        return Ok(new BookDto("title", "author", "subject", true));
    }
    
    [HttpPost]
    public async Task<ActionResult> Create([FromBody] BookCreatedDto book)
    {
        var bookEntity = new BookDto(book.Author, book.Title, book.Subject, true);
        return CreatedAtAction(nameof(GetById), new { id = 1 }, bookEntity);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] BookUpdatedDto book)
    {
        return Ok(book);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        return NoContent();
    }
}