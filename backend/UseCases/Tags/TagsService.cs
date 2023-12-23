namespace UseCases.Tags;

public interface ITagsService
{
    Task<TagDto> InsertAsync(SaveTagDto saveTagDto, CancellationToken cancellationToken = default);
}

public class TagsService : ITagsService
{
    public async Task<TagDto> InsertAsync(SaveTagDto saveTagDto, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}