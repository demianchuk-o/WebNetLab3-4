using LibrarySystem.Common.Books;
using LibrarySystem.Common.Loans;
using LibrarySystem.Common.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.WebAPI.Controllers;

[Authorize(Roles = "LoansManager")]
[ApiController]
[Route("api/[controller]")]
public class LoansController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<LoanDto>>> GetAll()
    {
        return Ok(new List<LoanDto>());
    }
    
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
    
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] LoanUpdatedDto loan)
    {
        return Ok(loan);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        return NoContent();
    }
}