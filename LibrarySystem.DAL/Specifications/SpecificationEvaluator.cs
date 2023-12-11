using LibrarySystem.DAL.Entities.Abstract;
using LibrarySystem.DAL.Specifications.Abstract;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.DAL.Specifications;

public static class SpecificationEvaluator
{
    public static IQueryable<TEntity> GetQuery<TEntity>(IQueryable<TEntity> inputQuery, Specification<TEntity> specification)
        where TEntity : class, IIdentity
    {
        var query = inputQuery;
        if (specification.Criteria is not null)
        {
            query = query.Where(specification.Criteria);
        }

        query = specification.Includes.
            Aggregate(query, 
                (current, includeExpression) => 
                    current.Include(includeExpression));

        return query;
    }
}