using EntityFrameworkCore.Entities.Base;

namespace EntityFrameworkCore.Repositories;

public interface IBaseRepository<TEntity, TId>
	where TEntity : AuditableEntity<TId>
{
	Task<TEntity?> GetAsync(TId id, CancellationToken cancellationToken = default);
	Task<TEntity[]> GetAllAsync(CancellationToken cancellationToken = default);
    
	Task DeleteAsync(
		TId id, 
		bool autoSave = true, 
		CancellationToken cancellationToken = default);
    
	Task DeleteAsync(
		TEntity? entity, 
		bool autoSave = true, 
		CancellationToken cancellationToken = default);
    
	Task DeleteRangeAsync(
		ICollection<TId> ids, 
		bool autoSave = true, 
		CancellationToken cancellationToken = default);
    
	Task DeleteRangeAsync(
		ICollection<TEntity> entities, 
		bool autoSave = true, 
		CancellationToken cancellationToken = default);
    
	Task<TEntity> UpdateAsync(
		TEntity entity, 
		bool autoSave = true, 
		CancellationToken cancellationToken = default);
    
	Task<TEntity[]> UpdateRangeAsync(
		ICollection<TEntity> entities, 
		bool autoSave = true, 
		CancellationToken cancellationToken = default);
    
	Task<TEntity> InsertAsync(
		TEntity entity, 
		bool autoSave = true, 
		CancellationToken cancellationToken = default);
    
	Task<TEntity[]> InsertRangeAsync(
		ICollection<TEntity> entities, 
		bool autoSave = true,
		CancellationToken cancellationToken = default);
    
	IQueryable<TEntity> GetQueryableAsync(CancellationToken cancellationToken = default);
}