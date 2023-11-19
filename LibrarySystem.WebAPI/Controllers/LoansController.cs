using LibrarySystem.Common.Books;
using LibrarySystem.Common.Loans;
using LibrarySystem.Common.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoansController : ControllerBase
{
    [Authorize(Roles = "LoansManager")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<LoanDto>>> GetAll()
    {
        return Ok(new List<LoanDto>());
    }
    
    [Authorize(Roles = "LoansManager")]
    [HttpGet("{id}")]
    public async Task<ActionResult<LoanDto>> GetById(Guid id)
    {
        return Ok(new LoanDto(Guid.NewGuid(), 
            new UserDto(Guid.NewGuid(),"username@mail.com", "username"),
            new List<BookDto>(),
            DateTime.Now,
            DateTime.Now.AddDays(7),
            null));
    }

    [Authorize(Roles = "Reader")]
    [HttpPost]
    public async Task<ActionResult> Create([FromBody] LoanCreatedDto loan)
    {
        var loanEntity = new LoanDto(Guid.NewGuid(),
            new UserDto(Guid.NewGuid(), "username@mail.com", "username"),
            new List<BookDto>(),
            DateTime.Now,
            DateTime.Now.AddDays(7),
            null);
        
        return CreatedAtAction(nameof(GetById), new { id = loanEntity.Id }, loanEntity);
    }
    
    [Authorize(Roles = "LoansManager")]
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] LoanUpdatedDto loan)
    {
        return Ok(loan);
    }
    
    [Authorize(Roles = "LoansManager")]
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        return NoContent();
    }
}