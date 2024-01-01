using System.Reflection.Emit;
using EntityFrameworkCore.Enums;

namespace UseCases.Tags;

public class SaveTagDto
{
    public string OldName { get; set; }
    public string NewName { get; set; }
    public TagCategory Category { get; set; }
    public bool IsNew { get; set; }
}