using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Entities;

public class Video : BaseMedia
{
	public string? ParentMediaId { get; set; }
	public Video? ParentMedia { get; set; }

	public List<Video>? ChildMedia { get; set; }
	public List<Tag>? Tags { get; set; }
}

public class VideoConfiguration : IEntityTypeConfiguration<Video>
{
	public void Configure(EntityTypeBuilder<Video> builder)
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