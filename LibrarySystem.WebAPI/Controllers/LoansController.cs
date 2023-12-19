using AutoMapper;
using LibrarySystem.Bll.Models;
using LibrarySystem.Bll.Services.Abstract;
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
    private readonly ILoanService _loanService;
    private readonly IMapper _mapper;
    public LoansController(ILoanService loanService, IMapper mapper)
    {
        _loanService = loanService;
        _mapper = mapper;
    }
    //[Authorize(Roles = "LoansManager")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<LoanDto>>> GetAll()
    {
        var loans = await _loanService.GetAllAsync();
        return _mapper.Map<IEnumerable<LoanDto>>(loans).ToList();
    }
    
    //[Authorize(Roles = "LoansManager")]
    [HttpGet("{id}")]
    public async Task<ActionResult<LoanDto>> GetById(Guid id)
    {
        var loan = await _loanService.GetByIdAsync(id);
        return _mapper.Map<LoanDto>(loan);
    }

    //[Authorize(Roles = "Reader")]
    [HttpPost]
    public async Task<ActionResult> Create([FromBody] LoanCreatedDto loan)
    {
        var loanId = await _loanService.AddAsync(_mapper.Map<LoanModel>(loan));
        
        var loanDto = _mapper.Map<LoanDto>(await _loanService.GetByIdAsync(loanId));
        
        return CreatedAtAction(nameof(GetById), new { id = loanDto.Id }, loanDto);
    }
    
    //[Authorize(Roles = "LoansManager")]
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] LoanUpdatedDto loan)
    {
        await _loanService.UpdateAsync(id, _mapper.Map<LoanModel>(loan));
        var loanDto = _mapper.Map<LoanDto>(await _loanService.GetByIdAsync(id));
        return Ok(loanDto);
    }
    
    //[Authorize(Roles = "LoansManager")]
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await _loanService.DeleteByIdAsync(id);
        return NoContent();
    }
}