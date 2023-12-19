using AutoMapper;
using LibrarySystem.Bll.Models;
using LibrarySystem.Common.Users;
using LibrarySystem.DAL.Entities;

namespace LibrarySystem.Bll.MappingProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserModel>();
        CreateMap<UserModel, User>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        
        CreateMap<UserRegisterDto, UserModel>();
        CreateMap<UserLoginDto, UserModel>();
        CreateMap<UserModel, UserDto>();
    }
}