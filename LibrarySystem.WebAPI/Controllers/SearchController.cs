using AutoMapper;
using LibrarySystem.Bll.Services.Abstract;
using LibrarySystem.Common.Books;
using LibrarySystem.Common.Search;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.WebAPI.Controllers;

[AllowAnonymous]
[ApiController]
[Route("api/[controller]")]
public class SearchController : ControllerBase
{
    private readonly IBookService _bookService;
    private readonly IMapper _mapper;

    public SearchController(IBookService bookService, IMapper mapper)
    {
        _bookService = bookService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookDto>>> GetSearchResults([FromQuery] SearchQueryDto query, [FromQuery] PaginationDto pagination)
    {
        var results = await _bookService.GetSearchResultsAsync(query, pagination);
        return Ok(_mapper.Map<IEnumerable<BookDto>>(results));
    }
}