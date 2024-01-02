using EntityFrameworkCore.Entities.Base;
using EntityFrameworkCore.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Entities;

public class MediaCatalog : AuditableEntity<int>
{
    public string MediaReferenceId { get; set; }
    public MediaReferenceTable? MediaReferenceTable { get; set; }
    public List<Tag>? Tags { get; set; }
}

public class MediaCatalogConfiguration : IEntityTypeConfiguration<MediaCatalog>
{
    public void Configure(EntityTypeBuilder<MediaCatalog> builder)
    {
        builder
            .Property(x => x.MediaReferenceTable)
            .HasConversion<string>();
        
        builder
            .HasMany(x => x.Tags)
            .WithMany(x => x.Media);
    }
}