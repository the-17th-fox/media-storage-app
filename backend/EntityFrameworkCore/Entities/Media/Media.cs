using EntityFrameworkCore.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Entities;

public abstract class Media : BaseEntity<string>
{
	public short SizeHorizontal { get; set; }
	public short SizeVertical { get; set; }
	public int SizeInKB { get; set; }

	/// <summary>
	/// If 'OnCloudDrive' is true, then SourceUrl represents the name of
	/// the file on the Cloud Disk, otherwise it represents external resource URL with this file.
	/// </summary>
	public required string Source { get; set; } 
	public bool OnCloudDrive { get; set; }

	public int LikesAmount { get; set; }

	public MediaRating? Rating { get; set; }
	public MediaModerationStatus? ModerationStatus { get; set; }

	public virtual List<Tag>? Tags { get; set; }

    // EFCore TPH below
    public required string Discriminator { get; set; }

	public string? ParentMediaId { get; set; }
	public Media? ParentMedia { get; set; }

	public virtual List<Media>? ChildMedia { get; set; }
}

public class MediaConfiguration : IEntityTypeConfiguration<Media>
{
	public void Configure(EntityTypeBuilder<Media> builder)
	{
		builder
			.HasMany(x => x.Tags)
			.WithMany(x => x.Media);

		builder
			.HasMany(x => x.ChildMedia)
			.WithOne(x => x.ParentMedia)
			.HasForeignKey(x => x.ParentMediaId)
			.OnDelete(DeleteBehavior.Restrict);

		builder
			.HasDiscriminator(x => x.Discriminator)
			.HasValue<Image>(nameof(Image))
			.HasValue<Gif>(nameof(Gif))
			.HasValue<Video>(nameof(Video));
	}
}