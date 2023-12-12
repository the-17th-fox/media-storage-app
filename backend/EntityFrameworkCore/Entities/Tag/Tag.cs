namespace EntityFrameworkCore.Entities;

/// <summary>
/// Id - represents tag's name
/// </summary>
public class Tag : BaseEntity<string>
{
    public virtual List<Media>? Media { get; set; }
}