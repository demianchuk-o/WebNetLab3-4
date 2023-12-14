using AutoMapper;
using LibrarySystem.Bll.Models;
using LibrarySystem.Bll.Services.Abstract;
using LibrarySystem.Common.Books;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.WebAPI.Controllers;

[Authorize(Roles = "CatalogManager")]
[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;
    private readonly IMapper _mapper;

    public BooksController(IBookService bookService, IMapper mapper)
    {
        _bookService = bookService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookDto>>> GetAll()
    {
        var books = await _bookService.GetAllAsync();
        return _mapper.Map<IEnumerable<BookDto>>(books).ToList();
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<BookDto>> GetById(Guid id)
    {
        var book = await _bookService.GetByIdAsync(id);
        return _mapper.Map<BookDto>(book);
    }
    
    [HttpPost]
    public async Task<ActionResult> Create([FromBody] BookCreatedDto book)
    {
        var bookId = await _bookService.AddAsync(_mapper.Map<BookModel>(book));
        var createdBook = _mapper.Map<BookDto>(await _bookService.GetByIdAsync(bookId));
        return CreatedAtAction(nameof(Create), new { id = bookId }, bookId);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] BookUpdatedDto book)
    {
        await _bookService.UpdateAsync(id, _mapper.Map<BookModel>(book));
        var bookEntity = _mapper.Map<BookDto>(await _bookService.GetByIdAsync(id));
        return Ok(bookEntity);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await _bookService.DeleteByIdAsync(id);
        return NoContent();
    }
}