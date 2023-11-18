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
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookDto>>> GetSearchResults([FromQuery] SearchQueryDto query, PaginationDto pagination)
    {
        return Ok(new List<BookDto>());
    }
}