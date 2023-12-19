using LibrarySystem.DAL.Entities.Abstract;

namespace LibrarySystem.Bll.Exceptions;

public class EntityNotFoundException<TEntity> : Exception
    where TEntity : class, IIdentity
{
    public EntityNotFoundException(Guid id)
        : base($"Entity of type {typeof(TEntity)} with id {id} was not found.")
    {
    }
}