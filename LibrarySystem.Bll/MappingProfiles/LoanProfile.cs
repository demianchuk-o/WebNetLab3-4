using AutoMapper;
using LibrarySystem.Bll.Models;
using LibrarySystem.DAL.Entities;

namespace LibrarySystem.Bll.MappingProfiles;

public class LoanProfile : Profile
{
    public LoanProfile()
    {
        CreateMap<Loan, LoanModel>()
            .ForMember(dest => dest.Borrower,
                opt => opt.MapFrom(src =>
                    new UserModel()
                    {
                        Id = src.Borrower.Id,
                        UserName = src.Borrower.UserName,
                        Email = src.Borrower.Email
                    }))
            .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Books
            .Select(b => new BookModel()
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author.Name,
                Subject = b.Subject.Name,
                Availability = b.Availability
            })));

        CreateMap<LoanModel, Loan>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.BorrowerId, opt => opt.MapFrom(src => src.Borrower.Id))
            .ForMember(dest => dest.Books, opt => opt.Ignore());
    }
}