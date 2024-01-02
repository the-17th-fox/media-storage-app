using AutoMapper;
using EntityFrameworkCore.Entities;
using EntityFrameworkCore.Repositories;
using UseCases.Media.Models;

namespace UseCases.Media;

public interface IBaseMediaService<TMedia>
{
	Task<MediaDto[]> GetAllAsync(CancellationToken cancellationToken = default);
	Task<MediaDto> SaveAsync(SaveMediaDto saveTagDto, CancellationToken cancellationToken = default);
}

public abstract class BaseBaseMediaService<TMedia> : IBaseMediaService<TMedia>
	where TMedia: BaseMedia<TMedia>
{
	protected BaseBaseMediaService(IBaseRepository<TMedia, int> baseRepository, IMapper mapper)
	{
		_baseRepository = baseRepository;
		_mapper = mapper;
	}
	
	private readonly IBaseRepository<TMedia, int> _baseRepository;
	private readonly IMapper _mapper;
	
	public async Task<MediaDto[]> GetAllAsync(CancellationToken cancellationToken = default)
	{
		var media = await _baseRepository.GetAllAsync(cancellationToken);
	
		return _mapper.Map<TMedia[], MediaDto[]>(media);
	}
	
	public async Task<MediaDto> SaveAsync(SaveMediaDto saveTagDto, CancellationToken cancellationToken = default)
	{
		var media = _mapper.Map<SaveMediaDto, TMedia>(saveTagDto);
	
		media = saveTagDto.IsNew
			? await _baseRepository.InsertAsync(media, autoSave: true, cancellationToken)
			: await _baseRepository.UpdateAsync(media, autoSave: true, cancellationToken);
	
		return _mapper.Map<TMedia, MediaDto>(media);
	}
}