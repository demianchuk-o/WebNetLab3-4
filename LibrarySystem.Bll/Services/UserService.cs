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
    private readonly IConfiguration _configuration;
    public UserService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager, IConfiguration configuration) : base(unitOfWork, mapper)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<UserModel?> GetByIdAsync(Guid id)
    {
        var entity = await UnitOfWork.Users.GetByIdAsync(id);
        
        if(entity is null)
            throw new EntityNotFoundException<User>(id);
        
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
        var entity = await UnitOfWork.Users.GetByIdAsync(id);
        
        if(entity is null)
            throw new EntityNotFoundException<User>(id);
        
        UnitOfWork.Users.Update(Mapper.Map(model, entity));
        await UnitOfWork.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(Guid id)
    {
        await UnitOfWork.Users.DeleteByIdAsync(id);
    }

    public async Task<UserModel?> GetByEmailAsync(string email)
    {
        var userByEmail = await UnitOfWork.Users.GetByEmailAsync(email);
        return userByEmail is null ? null : Mapper.Map<UserModel>(userByEmail);
    }

    public async Task<string> AuthenticateAsync(string email, string password)
    {
        var user = await UnitOfWork.Users.GetByEmailAsync(email);
        
        if (user is null)
            return null;

        var result = await _userManager.CheckPasswordAsync(user, password);
        
        if (!result)
            return null;

        var roleName = await UnitOfWork.Users.GetRoleNameAsync(user);

        var factory = new JwtFactory(_configuration);
        
        return factory.GenerateJwt(user, roleName);
    }

    public async Task RegisterAsync(UserModel model, string password)
    {
        await ThrowIfUserAlreadyExists(model);
        
        await _userManager.CreateAsync(Mapper.Map<User>(model), password);
    }
    
    private async Task ThrowIfUserAlreadyExists(UserModel model)
    {
        var userEntity = await UnitOfWork.Users.GetByEmailAsync(model.Email);
        
        if (userEntity is not null)
            throw new UserAlreadyExistsException(model.Email);
    }
}