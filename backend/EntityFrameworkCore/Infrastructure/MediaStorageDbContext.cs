using System.Reflection;
using EntityFrameworkCore.Entities;
using EntityFrameworkCore.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EntityFrameworkCore.Infrastructure;

public class MediaStorageDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
	public MediaStorageDbContext(
		DbContextOptions<MediaStorageDbContext> options,
		IUserIdResolver userIdResolver)
		: base(options)
	{
		_userIdResolver = userIdResolver ?? throw new ArgumentNullException(nameof(userIdResolver));
	}

	public DbSet<Gif> Gifs { get; set; } = null!;
	public DbSet<Image> Images { get; set; } = null!;
	public DbSet<Video> Videos { get; set; } = null!;
	
	public DbSet<MediaCatalog> MediaCatalogs { get; set; } = null!;
	
	public DbSet<Tag> Tags { get; set; } = null!;
	
	private readonly IUserIdResolver _userIdResolver;

    protected override void OnModelCreating(ModelBuilder builder)
	{
		builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

		base.OnModelCreating(builder);
	}

	public override int SaveChanges()
	{
		UpdateAuditableProperties();
		return base.SaveChanges();
	}

	public override int SaveChanges(bool acceptAllChangesOnSuccess)
	{
		UpdateAuditableProperties();
        return base.SaveChanges(acceptAllChangesOnSuccess);
	}

	public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
	{
		UpdateAuditableProperties();
        return await base.SaveChangesAsync(cancellationToken);
	}

	public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
	{
		UpdateAuditableProperties();
        return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
	}

	private void UpdateAuditableProperties()
	{
		var entries = ChangeTracker.Entries()
			.Where(e =>
				(e.State
					is EntityState.Deleted
					or EntityState.Modified
					or EntityState.Added) &&
				e.Entity is IAuditableEntity);

		foreach (var entry in entries)
		{
			switch (entry.State)
			{
				case EntityState.Deleted:
					PerformDelete(entry);
					break;

				case EntityState.Modified:
					PerformUpdate(entry);
					break;

				case EntityState.Added:
					PerformCreate(entry);
					break;
			}
		}
	}

	private void PerformDelete(EntityEntry entry)
	{
		if (entry.Entity is not IAuditableEntity entity)
			return;

		entry.State = EntityState.Modified;
		entity.IsDeleted = true;
		entity.DeletedBy = _userIdResolver.Resolve();
		entity.DeletedAt = DateTime.UtcNow;
	}

	private void PerformUpdate(EntityEntry entry)
	{
		if (entry.Entity is not IAuditableEntity entity)
			return;

		entity.UpdatedBy = _userIdResolver.Resolve();
	}

	private void PerformCreate(EntityEntry entry)
	{
		if (entry.Entity is not IAuditableEntity entity)
			return;

		entity.CreatedBy = _userIdResolver.Resolve();
	}
}