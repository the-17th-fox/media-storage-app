using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Entities.Base;

public abstract class AuditableEntity<TKey> : BaseEntity<TKey>, IAuditableEntity
{
	public DateTime CreatedAt { get; set; }
	public Guid CreatedBy { get; set; }

	public DateTime? UpdatedAt { get; set; }
	public Guid? UpdatedBy { get; set; }

	public DateTime? DeletedAt { get; set; }
	public Guid? DeletedBy { get; set; }
	public bool IsDeleted { get; set; }
}

public abstract class AuditableEntityConfiguration<TEntity, TKey> : BaseEntityConfiguration<TEntity, TKey>
	where TEntity: AuditableEntity<TKey>
{
	public override void Configure(EntityTypeBuilder<TEntity> builder)
	{
		base.Configure(builder);
		
		builder
			.Property(e => e.CreatedAt)
			.HasDefaultValueSql("GETUTCDATE()")
			.ValueGeneratedOnAdd();

		builder
			.Property(e => e.UpdatedAt)
			.HasDefaultValueSql("GETUTCDATE()")
			.ValueGeneratedOnUpdate();

		builder
			.Property(e => e.IsDeleted)
			.HasDefaultValue(false);
	}
}