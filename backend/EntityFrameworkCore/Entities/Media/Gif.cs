using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Entities;

public class Gif : BaseMedia
{
	public string? ParentMediaId { get; set; }
	public Gif? ParentMedia { get; set; }

	public List<Gif>? ChildMedia { get; set; }
	public List<Tag>? Tags { get; set; }
}

public class GifConfiguration : IEntityTypeConfiguration<Gif>
{
	public void Configure(EntityTypeBuilder<Gif> builder)
	{
		builder
			.HasMany(x => x.Tags)
			.WithMany();

		builder
			.HasMany(x => x.ChildMedia)
			.WithOne(x => x.ParentMedia)
			.HasForeignKey(x => x.ParentMediaId)
			.OnDelete(DeleteBehavior.NoAction);
	}
}