using LibrarySystem.DAL.Entities.Abstract;

namespace LibrarySystem.DAL.Repositories.Abstract;

public interface IRepository<TEntity> 
    where TEntity : class, IIdentity
{
    Task<TEntity?> GetByIdAsync(Guid id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task AddAsync(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    Task DeleteByIdAsync(Guid id);
}