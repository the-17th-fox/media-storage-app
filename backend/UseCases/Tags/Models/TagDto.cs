namespace UseCases.Tags;

public class TagDto
{
    public string TagName { get; set; }

    public TagDto(string tagName)
    {
        TagName = tagName;
    }
}