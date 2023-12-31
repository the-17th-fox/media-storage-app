using EntityFrameworkCore.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Entities;

public abstract class BaseMedia<TEntity> : BaseEntity<int> where TEntity: BaseMedia<TEntity>
{
	public short SizeHorizontal { get; set; }
	public short SizeVertical { get; set; }
	public int SizeInKb { get; set; }

	/// <summary>
	/// If 'OnCloudDrive' is true, then SourceUrl represents the name of
	/// the file on the Cloud Disk, otherwise it represents external resource URL with this file.
	/// </summary>
	public string Source { get; set; } 
	public bool OnCloudDrive { get; set; }

	public int LikesAmount { get; set; }

	public MediaRating? Rating { get; set; }
	public MediaModerationStatus? ModerationStatus { get; set; }
	
	public int? ParentMediaId { get; set; }
	public TEntity? ParentMedia { get; set; }

	public List<TEntity>? ChildMedia { get; set; }
}

public class BaseMediaConfiguration<TMedia> : IEntityTypeConfiguration<TMedia> where TMedia: BaseMedia<TMedia>
{
	public void Configure(EntityTypeBuilder<TMedia> builder)
	{
		builder
			.Property(x => x.Source)
			.HasMaxLength(2048);
		
		builder
			.Property(x => x.Source)
			.HasMaxLength(2048);

		builder
			.Property(x => x.Rating)
			.HasConversion<string>();

		builder
			.Property(x => x.ModerationStatus)
			.HasConversion<string>();
		
		builder
			.HasMany(x => x.ChildMedia)
			.WithOne(x => x.ParentMedia)
			.HasForeignKey(x => x.ParentMediaId)
			.OnDelete(DeleteBehavior.NoAction);
	}
}