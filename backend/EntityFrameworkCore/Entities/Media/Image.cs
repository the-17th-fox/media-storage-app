using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Entities;

public class Image : BaseMedia
{
	public string? ParentMediaId { get; set; }
	public Image? ParentMedia { get; set; }

	public List<Image>? ChildMedia { get; set; }
	public List<Tag>? Tags { get; set; }
}

public class ImageConfiguration : IEntityTypeConfiguration<Image>
{
	public void Configure(EntityTypeBuilder<Image> builder)
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