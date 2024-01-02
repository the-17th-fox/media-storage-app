using EntityFrameworkCore.Entities.Base;
using EntityFrameworkCore.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Entities;

/// <summary>
/// Id - represents tag's name
/// </summary>
public class Tag : AuditableEntity<string>
{
    public TagCategory? Category { get; set; }
    public List<MediaCatalog>? Media { get; set; }
}

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder
            .Property(x => x.Category)
            .HasConversion<string>();
    }
}