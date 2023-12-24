using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Entities;

public class Gif : BaseMedia
{
	public int? ParentMediaId { get; set; }
	public Gif? ParentMedia { get; set; }

	public List<Gif>? ChildMedia { get; set; }
}

public class GifConfiguration : /*BaseMediaConfiguration,*/ IEntityTypeConfiguration<Gif>
{
	public void Configure(EntityTypeBuilder<Gif> builder)
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