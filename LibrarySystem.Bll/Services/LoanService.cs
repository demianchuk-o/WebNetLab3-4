using AutoMapper;
using LibrarySystem.Bll.Exceptions;
using LibrarySystem.Bll.Models;
using LibrarySystem.Bll.Services.Abstract;
using LibrarySystem.DAL.Entities;
using LibrarySystem.DAL.UnitOfWork.Abstract;

namespace LibrarySystem.Bll.Services;

public class LoanService : BaseService, ILoanService
{
    public LoanService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public async Task<LoanModel?> GetByIdAsync(Guid id)
    {
        var entity = await UnitOfWork.Loans.GetByIdAsync(id);
        
        if(entity is null)
            throw new EntityNotFoundException<Loan>(id);
        
        return Mapper.Map<LoanModel>(entity);
    }

    public async Task<IEnumerable<LoanModel>> GetAllAsync()
    {
        var entities = await UnitOfWork.Loans.GetAllAsync();
        
        return Mapper.Map<IEnumerable<LoanModel>>(entities);
    }

    public async Task AddAsync(LoanModel model)
    {
        var entity = Mapper.Map<Loan>(model);
        entity.Id = Guid.NewGuid();
        
        await UnitOfWork.Loans.AddAsync(entity);
        await UnitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(Guid id, LoanModel model)
    {
        var entity = await UnitOfWork.Loans.GetByIdAsync(id);
        
        if(entity is null)
            throw new EntityNotFoundException<Loan>(id);
        
        UnitOfWork.Loans.Update(Mapper.Map(model, entity));
        await UnitOfWork.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(Guid id)
    {
        await UnitOfWork.Loans.DeleteByIdAsync(id);
    }

    public async Task MakeLoanAsync(LoanModel model)
    {
        await ValidateLoanAsync(model);

        await AddAsync(model);
    }
    
    private async Task ValidateLoanAsync(LoanModel model)
    {
        var borrower = await UnitOfWork.Users.GetByIdAsync(model.Borrower.Id);

        if (borrower is null)
            throw new EntityNotFoundException<User>(model.Borrower.Id);

        const int maxBooks = 10;
        if (model.Books.Count > maxBooks)
            throw new MaxBooksException(maxBooks);
        
        foreach (var bookDto in model.Books)
        {
            await ValidateBookAvailabilityAsync(bookDto);
        }
    }

    private async Task ValidateBookAvailabilityAsync(BookModel bookDto)
    {
        var bookEntity = await UnitOfWork.Books.GetByIdAsync(bookDto.Id);

        if (bookEntity is null)
            throw new EntityNotFoundException<Book>(bookDto.Id);

        var book = Mapper.Map<BookModel>(bookEntity);
        if (!book.IsAvailable())
            throw new BookNotAvailableException(book.Id);
    }

    public async Task ReturnLoanAsync(Guid id)
    {
        var entity = await UnitOfWork.Loans.GetByIdWithUserAndBooksAsync(id);
        
        if(entity is null)
            throw new EntityNotFoundException<Loan>(id);
        
        MarkLoanAsReturned(entity);
        
        UpdateBooksAvailability(entity.Books);

        await UnitOfWork.SaveChangesAsync();
    }
    
    private void MarkLoanAsReturned(Loan loanEntity)
    {
        loanEntity.ReturnDate = DateTime.Now;
        UnitOfWork.Loans.Update(loanEntity);
    }

    private void UpdateBooksAvailability(IEnumerable<Book> books)
    {
        foreach (var book in books)
        {
            book.Availability = true;
            UnitOfWork.Books.Update(book);
        }
    }
}