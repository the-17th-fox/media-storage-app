using AutoMapper;
using EntityFrameworkCore.Entities;
using EntityFrameworkCore.Repositories;

namespace UseCases.Media;

public interface IImagesService : IBaseMediaService<Image>
{
	
}

public class ImagesService : BaseBaseMediaService<Image>, IImagesService
{
	public ImagesService(IBaseRepository<Image, int> baseRepository, IMapper mapper) : base(baseRepository, mapper)
	{
	}
}