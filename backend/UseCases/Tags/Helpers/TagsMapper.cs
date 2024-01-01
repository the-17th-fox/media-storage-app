using AutoMapper;
using EntityFrameworkCore.Entities;

namespace UseCases.Tags.Helpers;

public class TagsMapper : Profile
{
    public TagsMapper()
    {
        CreateMap<Tag, TagDto>()
            .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Id));

        CreateMap<SaveTagDto, Tag>()
            .ForMember(x => x.Id, opt => opt.MapFrom(src => src.NewName));
    }
}