﻿using Microsoft.AspNetCore.Identity;

namespace EntityFrameworkCore.Entities;

public class User : IdentityUser<Guid>, IAuditableEntity, IBaseEntity<Guid>
{
	public DateTimeOffset CreatedAt { get; set; }
	public Guid CreatedBy { get; set; }

	public DateTimeOffset? UpdatedAt { get; set; }
	public Guid? UpdatedBy { get; set; }

	public DateTimeOffset? DeletedAt { get; set; }
	public Guid? DeletedBy { get; set; }
	public bool IsDeleted { get; set; }
}