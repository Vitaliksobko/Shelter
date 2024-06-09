using AutoMapper;
using Shelter.Core.Dtos;
using Shelter.Core.Models;

namespace Shelter.Api.MappingProfile;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AnimalDto, Animal>().ReverseMap();
        CreateMap<NewsDto, News>().ReverseMap();
        CreateMap<QuestionDto, Question>().ReverseMap();
        
    }
}