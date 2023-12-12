
using LibrarySystem.Bll.Models.Abstract;

namespace LibrarySystem.Bll.Services.Abstract;

public interface ICrudService<TModel>
    where TModel : class, IModel
{
    Task<TModel?> GetByIdAsync(Guid id);
    Task<IEnumerable<TModel>> GetAllAsync();
    Task AddAsync(TModel model);
    Task UpdateAsync(TModel model);
    Task DeleteByIdAsync(Guid id);
}