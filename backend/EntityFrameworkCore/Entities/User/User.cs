﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Entities;

public class User : IdentityUser<Guid>, IAuditableEntity
{
	public DateTime CreatedAt { get; set; }
	public Guid CreatedBy { get; set; }

	public DateTime? UpdatedAt { get; set; }
	public Guid? UpdatedBy { get; set; }

	public DateTime? DeletedAt { get; set; }
	public Guid? DeletedBy { get; set; }
	public bool IsDeleted { get; set; }
}

public class UserConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.HasKey(x => x.Id);
		
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