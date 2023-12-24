using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Entities;

public class Image : BaseMedia
{
	public int? ParentMediaId { get; set; }
	public Image? ParentMedia { get; set; }

	public List<Image>? ChildMedia { get; set; }
}

public class ImageConfiguration : /*BaseMediaConfiguration,*/ IEntityTypeConfiguration<Image>
{
	public void Configure(EntityTypeBuilder<Image> builder)
	{
		builder
			.Property(x => x.Source)
			.HasMaxLength(2048);
		
		builder
			.HasMany(x => x.ChildMedia)
			.WithOne(x => x.ParentMedia)
			.HasForeignKey(x => x.ParentMediaId)
			.OnDelete(DeleteBehavior.NoAction);
	}
}