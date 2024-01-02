using AutoMapper;
using EntityFrameworkCore.Entities;
using EntityFrameworkCore.Enums;
using UseCases.Media.Models;

namespace UseCases.Media;

public class MediaMapper : Profile
{
	public MediaMapper()
	{
		// viewing dtos
		CreateMap<Video, MediaDto>()
			.ForMember(x => x.Type, opt => opt.MapFrom(src => MediaReferenceTable.Video));
		
		CreateMap<Gif, MediaDto>()
			.ForMember(x => x.Type, opt => opt.MapFrom(src => MediaReferenceTable.Gif));
		
		CreateMap<Image, MediaDto>()
			.ForMember(x => x.Type, opt => opt.MapFrom(src => MediaReferenceTable.Image));
		
		// saving dtos
		CreateMap<SaveMediaDto, Video>();
		CreateMap<SaveMediaDto, Gif>();
		CreateMap<SaveMediaDto, Image>();
	}
}