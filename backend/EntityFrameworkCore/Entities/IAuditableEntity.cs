﻿using Microsoft.EntityFrameworkCore;
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