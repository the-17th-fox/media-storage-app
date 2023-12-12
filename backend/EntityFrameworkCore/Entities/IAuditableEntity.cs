using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Entities;

public interface IAuditableEntity
{
	public DateTimeOffset CreatedAt { get; set; }
	public Guid CreatedBy { get; set; }

	public DateTimeOffset? UpdatedAt { get; set; }
	public Guid? UpdatedBy { get; set; }

	public DateTimeOffset? DeletedAt { get; set; }
	public Guid? DeletedBy { get; set; }
	public bool IsDeleted { get; set; }
}

public class AuditableEntityConfiguration : IEntityTypeConfiguration<IAuditableEntity>
{
	public void Configure(EntityTypeBuilder<IAuditableEntity> builder)
	{
		builder
			.Property(e => e.CreatedAt)
			.HasDefaultValueSql("GETUTCDATE()")
			.ValueGeneratedOnAdd();

		builder
			.Property(e => e.UpdatedAt)
			.HasDefaultValueSql("GETUTCDATE()")
			.ValueGeneratedOnAddOrUpdate();

		builder
			.Property(e => e.IsDeleted)
			.HasDefaultValue(false);
    }
}