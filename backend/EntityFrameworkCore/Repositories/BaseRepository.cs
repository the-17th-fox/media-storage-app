using EntityFrameworkCore.Entities;
using EntityFrameworkCore.Entities.Base;
using EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.Repositories;

public class BaseRepository<TEntity, TId> : 
    IBaseRepository<TEntity, TId> where TEntity: AuditableEntity<TId>
{
    public BaseRepository(MediaStorageDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _dbSet = dbContext.Set<TEntity>();
    }
    
    private readonly MediaStorageDbContext _dbContext;
    private readonly DbSet<TEntity> _dbSet;

    public Task<TEntity?> GetAsync(TId id, CancellationToken cancellationToken = default)
    {
        return _dbSet
            .FirstOrDefaultAsync(
                x => !x.IsDeleted &&
                     x.Id.Equals(id), 
                cancellationToken);
    }

    public Task<TEntity[]> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return _dbSet
            .Where(x => !x.IsDeleted)
            .ToArrayAsync(cancellationToken);
    }

    public async Task<TEntity> InsertAsync(
        TEntity entity, 
        bool autoSave = true, 
        CancellationToken cancellationToken = default)
    {
        _dbSet.Add(entity);

        if (autoSave)
            await _dbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public async Task<TEntity[]> InsertRangeAsync(
        ICollection<TEntity> entities, 
        bool autoSave = true,
        CancellationToken cancellationToken = default)
    {
        _dbSet.AddRange(entities);
        
        if (autoSave)
            await _dbContext.SaveChangesAsync(cancellationToken);

        return entities.ToArray();
    }

    public async Task DeleteAsync(
        TId id, 
        bool autoSave = true, 
        CancellationToken cancellationToken = default)
    {
        var entity = await _dbSet
            .FirstOrDefaultAsync(x => 
                !x.IsDeleted &&
                x.Id.Equals(id),
            cancellationToken);
        
        if (entity is null)
            return;

        await DeleteAsync(entity, autoSave, cancellationToken);
    }

    public async Task DeleteAsync(
        TEntity? entity, 
        bool autoSave = true, 
        CancellationToken cancellationToken = default)
    {
        if (entity is null)
            return;

        _dbSet.Remove(entity);

        if (autoSave)
            await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteRangeAsync(
        ICollection<TId> ids, 
        bool autoSave = true,
        CancellationToken cancellationToken = default)
    {
        var entities = await _dbSet
            .Where(x => ids.Contains(x.Id) &&
                        !x.IsDeleted)
            .ToArrayAsync(cancellationToken);
        
        if(!entities.Any())
            return;

        await DeleteRangeAsync(entities, autoSave, cancellationToken);
    }
    
    public async Task DeleteRangeAsync(
        ICollection<TEntity> entities, 
        bool autoSave = true,
        CancellationToken cancellationToken = default)
    {
        if(!entities.Any())
            return;
        
        _dbSet.RemoveRange(entities);

        if (autoSave)
            await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<TEntity> UpdateAsync(
        TEntity entity, 
        bool autoSave = true, 
        CancellationToken cancellationToken = default)
    {
        _dbSet.Update(entity);
        
        if (autoSave)
            await _dbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public async Task<TEntity[]> UpdateRangeAsync(
        ICollection<TEntity> entities, 
        bool autoSave = true,
        CancellationToken cancellationToken = default)
    {
        _dbSet.UpdateRange(entities);
        
        if (autoSave)
            await _dbContext.SaveChangesAsync(cancellationToken);

        return entities.ToArray();
    }

    public IQueryable<TEntity> GetQueryableAsync(CancellationToken cancellationToken = default)
        => _dbSet.AsQueryable();
}