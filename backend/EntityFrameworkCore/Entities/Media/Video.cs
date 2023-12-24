using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Entities;

public class Video : BaseMedia
{
	public int? ParentMediaId { get; set; }
	public Video? ParentMedia { get; set; }

	public List<Video>? ChildMedia { get; set; }
}

public class VideoConfiguration : /*BaseMediaConfiguration,*/ IEntityTypeConfiguration<Video>
{
	public void Configure(EntityTypeBuilder<Video> builder)
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