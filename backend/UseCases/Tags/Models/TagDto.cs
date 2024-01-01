using EntityFrameworkCore.Enums;

namespace UseCases.Tags;

public class TagDto
{
    public string Name { get; set; }
    public TagCategory Category { get; set; }
}