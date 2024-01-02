using EntityFrameworkCore.Enums;

namespace UseCases.Media.Models;

public class SaveMediaDto
{
	public short SizeHorizontal { get; set; }
	public short SizeVertical { get; set; }
	public int SizeInKb { get; set; }
	public string Source { get; set; } 
	public bool OnCloudDrive { get; set; }
	public int LikesAmount { get; set; }
	public MediaRating? Rating { get; set; }
	public MediaModerationStatus? ModerationStatus { get; set; }
	public int? ParentMediaId { get; set; }
	public bool IsNew { get; set; }
	public MediaReferenceTable Type { get; set; }
}