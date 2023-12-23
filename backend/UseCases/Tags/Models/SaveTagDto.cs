using System.Reflection.Emit;

namespace UseCases.Tags;

public class SaveTagDto
{
    public string OldTagName { get; set; }
    public string NewTagName { get; set; }
}