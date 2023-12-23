namespace EntityFrameworkCore.Entities;

/// <summary>
/// Id - represents tag's name
/// </summary>
public class Tag : BaseEntity<string>
{
    public List<MediaCatalog>? Media { get; set; }
}