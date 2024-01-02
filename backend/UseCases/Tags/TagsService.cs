using AutoMapper;
using EntityFrameworkCore.Entities;
using EntityFrameworkCore.Repositories;

namespace UseCases.Tags;

public interface ITagsService
{
    Task<TagDto> SaveAsync(SaveTagDto saveTagDto, CancellationToken cancellationToken = default);
    Task<TagDto[]> GetAllAsync(CancellationToken cancellationToken = default);
}

public class TagsService : ITagsService
{
    public TagsService(IBaseRepository<Tag, string> repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    private readonly IBaseRepository<Tag, string> _repository;
    private readonly IMapper _mapper;
    
    public async Task<TagDto> SaveAsync(
        SaveTagDto saveTagDto, 
        CancellationToken cancellationToken = default)
    {
        var tag = _mapper.Map<Tag>(saveTagDto);
        
        tag = saveTagDto.IsNew
            ? await _repository.InsertAsync(tag, autoSave: true, cancellationToken)
            : await _repository.UpdateAsync(tag, autoSave: true, cancellationToken);

        return _mapper.Map<TagDto>(tag);
    }

    public async Task<TagDto[]> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var tags = await _repository.GetAllAsync(cancellationToken);

        return _mapper.Map<TagDto[]>(tags);
    }
}