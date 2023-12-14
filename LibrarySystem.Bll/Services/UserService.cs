using AutoMapper;
using LibrarySystem.Bll.Exceptions;
using LibrarySystem.Bll.Models;
using LibrarySystem.Bll.Security;
using LibrarySystem.Bll.Services.Abstract;
using LibrarySystem.DAL.Entities;
using LibrarySystem.DAL.UnitOfWork.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace LibrarySystem.Bll.Services;

public class UserService : BaseService, IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly JwtFactory _jwtFactory;
    public UserService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager, JwtFactory jwtFactory) : base(unitOfWork, mapper)
    {
        _userManager = userManager;
        _jwtFactory = jwtFactory;
    }

    public async Task<UserModel?> GetByIdAsync(Guid id)
    {
        var entity = await GetUserByIdOrThrowAsync(id);
        
        return Mapper.Map<UserModel>(entity);
    }

    public async Task<IEnumerable<UserModel>> GetAllAsync()
    {
        var entities = await UnitOfWork.Users.GetAllAsync();
        
        return Mapper.Map<IEnumerable<UserModel>>(entities);
    }

    public async Task AddAsync(UserModel model)
    {
        var entity = Mapper.Map<User>(model);
        entity.Id = Guid.NewGuid();
        
        await _userManager.CreateAsync(entity);
    }

    public async Task UpdateAsync(Guid id, UserModel model)
    {
        var entity = await GetUserByIdOrThrowAsync(id);
        
        UnitOfWork.Users.Update(Mapper.Map(model, entity));
        await UnitOfWork.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(Guid id)
    {
        await UnitOfWork.Users.DeleteByIdAsync(id);
    }

    public async Task<UserModel?> GetByEmailAsync(string email)
    {
        var userByEmail = await GetUserByEmailOrThrowAsync(email);
        
        return Mapper.Map<UserModel>(userByEmail);
    }

    public async Task<string> AuthenticateAsync(string email, string password)
    {
        var user = await GetUserByEmailOrThrowAsync(email);

        var result = await _userManager.CheckPasswordAsync(user, password);
        
        if (!result)
            throw new InvalidCredentialsException(email); 

        var roleName = await UnitOfWork.Users.GetRoleNameAsync(user);
        
        return _jwtFactory.GenerateJwt(user, roleName);
    }
    

    public async Task RegisterAsync(UserModel model, string password)
    {
        await ThrowIfUserAlreadyExists(model);
        var user = Mapper.Map<User>(model);
        user.Id = Guid.NewGuid();
        
        await _userManager.CreateAsync(user, password);
    }
    
    private async Task<User> GetUserByIdOrThrowAsync(Guid id)
    {
        var userById = await UnitOfWork.Users.GetByIdAsync(id);
        
        if (userById is null)
            throw new EntityNotFoundException<User>(id);
        
        return userById;
    }
    
    private async Task<User> GetUserByEmailOrThrowAsync(string email)
    {
        var userByEmail = await UnitOfWork.Users.GetByEmailAsync(email);
        
        if (userByEmail is null)
            throw new UserWithEmailNotFoundException(email);
        
        return userByEmail;
    }
    
    private async Task ThrowIfUserAlreadyExists(UserModel model)
    {
        var userEntity = await UnitOfWork.Users.GetByEmailAsync(model.Email);
        
        if (userEntity is not null)
            throw new UserAlreadyExistsException(model.Email);
    }
}