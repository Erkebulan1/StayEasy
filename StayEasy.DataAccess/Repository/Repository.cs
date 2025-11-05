using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using StayEasy.DataAccess.Contexts;
using StayEasy.DataAccess.Repository;
using StayEasy.Domain;
using StayEasy.Domain.Entities;

namespace StayEasy.DataAccess.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
     this._context = context;
     _context.Set<TEntity>();
    }
    public async Task InsertAsync(TEntity entity)
    {
        entity.CreatedAt=DateTime.UtcNow;
        _context.Add(entity);
    }

    public async Task UpdateAsync(TEntity entity)
    {
        entity.UpdatedAt = DateTime.UtcNow;
        _context.Update(entity);
    }

    public async Task DeleteAsync(TEntity entity)
    {
        entity.DeletedAt = DateTime.UtcNow;
        entity.IsDeleted = true;
        _context.Entry(entity).Property(e => e.DeletedAt).IsModified = true;
        _context.Entry(entity).Property(e => e.IsDeleted).IsModified = true; 
    }

    public async Task InsertRangeAsync(IEnumerable<TEntity> entities)
    {
        await entities.AsQueryable().ForEachAsync(entity =>
        {
            entity.CreatedAt = DateTime.UtcNow;

            _context.Add(entity);
        });
    }

    public async Task<TEntity> SelectAsync(Expression<Func<TEntity, bool>> predicate, string[] includes = null)
    {
        var query = _context.Set<TEntity>().Where(predicate).AsQueryable();

        if (includes != null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }
        
        return await query.FirstOrDefaultAsync(predicate);
    }

    public IQueryable<TEntity> SelectAllAsQueryable()
    {
        return _context.Set<TEntity>().AsQueryable();
    }
}
