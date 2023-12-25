using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Entities;

public interface IBaseEntity<TKey>
{
	public TKey Id { get; set; }
}

public class BaseEntity<TKey> : IBaseEntity<TKey>, IAuditableEntity
{
	public required TKey Id { get; set; }

	public DateTimeOffset CreatedAt { get; set; }
	public Guid CreatedBy { get; set; }

	public DateTimeOffset? UpdatedAt { get; set; }
	public Guid? UpdatedBy { get; set; }

	public DateTimeOffset? DeletedAt { get; set; }
	public Guid? DeletedBy { get; set; }
	public bool IsDeleted { get; set; }
}

public class BaseEntityConfiguration<TKey> : IEntityTypeConfiguration<BaseEntity<TKey>>
{
	public void Configure(EntityTypeBuilder<BaseEntity<TKey>> builder)
	{
		builder.HasKey(e => e.Id);
		
		builder
			.Property(e => e.CreatedAt)
			.HasDefaultValueSql("SYSDATETIMEOFFSET()")
			.ValueGeneratedOnAdd();

		builder
			.Property(e => e.UpdatedAt)
			.HasDefaultValueSql("SYSDATETIMEOFFSET()")
			.ValueGeneratedOnAddOrUpdate();

		builder
			.Property(e => e.IsDeleted)
			.HasDefaultValue(false);
	}
}