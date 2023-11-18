using LibrarySystem.Common.Books;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.WebAPI.Controllers;

[Authorize(Roles = "CatalogManager")]
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
    public async Task<ActionResult<BookDto>> GetById(Guid id)
    {
        return Ok(new BookDto(Guid.NewGuid(),"title", "author", "subject", true));
    }
    
    [HttpPost]
    public async Task<ActionResult> Create([FromBody] BookCreatedDto book)
    {
        var bookEntity = new BookDto(Guid.NewGuid(),book.Author, book.Title, book.Subject, true);
        return CreatedAtAction(nameof(GetById), new { id = bookEntity.Id }, bookEntity);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] BookUpdatedDto book)
    {
        return Ok(book);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        return NoContent();
    }
}