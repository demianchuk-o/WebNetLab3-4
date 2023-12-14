using AutoMapper;
using LibrarySystem.Bll.Models;
using LibrarySystem.DAL.Entities;

namespace LibrarySystem.Bll.MappingProfiles;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<Book, BookModel>()
            .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name))
            .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject.Name));

        CreateMap<BookModel, Book>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Author, opt => opt.Ignore())
            .ForMember(dest => dest.Subject, opt => opt.Ignore());
    }
}