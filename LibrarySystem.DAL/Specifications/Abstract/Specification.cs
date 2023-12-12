using System.Linq.Expressions;
using LibrarySystem.DAL.Entities.Abstract;

namespace LibrarySystem.DAL.Specifications.Abstract;

public abstract class Specification<TEntity>
    where TEntity : class, IIdentity
{
    public Expression<Func<TEntity, bool>>? Criteria { get; }

    public int Skip { get; private set; } = 0;
    public int Take { get; private set; } = 0;
    
    protected Specification(Expression<Func<TEntity, bool>>? criteria)
    {
        Criteria = criteria;
    }
    public List<Expression<Func<TEntity, object>>> Includes { get; } = new();
    
    protected void AddInclude(Expression<Func<TEntity, object>> includeExpression)
    {
        Includes.Add(includeExpression);
    }
    
    protected void AddPaging(int skip, int take)
    {
        Skip = skip;
        Take = take;
    }
}