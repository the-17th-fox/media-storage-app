using EntityFrameworkCore.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Entities;

public abstract class BaseMedia : BaseEntity<int>
{
	public short SizeHorizontal { get; set; }
	public short SizeVertical { get; set; }
	public int SizeInKb { get; set; }

	/// <summary>
	/// If 'OnCloudDrive' is true, then SourceUrl represents the name of
	/// the file on the Cloud Disk, otherwise it represents external resource URL with this file.
	/// </summary>
	public required string Source { get; set; } 
	public bool OnCloudDrive { get; set; }

	public int LikesAmount { get; set; }

	public MediaRating? Rating { get; set; }
	public MediaModerationStatus? ModerationStatus { get; set; }
}

// public abstract class BaseMediaConfiguration : IEntityTypeConfiguration<BaseMedia>
// {
// 	public void Configure(EntityTypeBuilder<BaseMedia> builder)
// 	{
// 		builder
// 			.Property(x => x.Source)
// 			.HasMaxLength(2048);
// 	}
// }