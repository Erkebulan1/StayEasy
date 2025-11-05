using System.Linq.Expressions;

namespace StayEasy.DataAccess.Repository;

public interface IRepository<TEntity> where TEntity: class
{
    Task InsertAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
    Task InsertRangeAsync (IEnumerable<TEntity> entities);
    Task<TEntity> SelectAsync(Expression<Func<TEntity, bool>> predicate, string[] includes = null);
    
    IQueryable<TEntity> SelectAllAsQueryable(); 
}