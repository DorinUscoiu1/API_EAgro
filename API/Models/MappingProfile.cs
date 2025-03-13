using AutoMapper;
using API.DTOs;
using API.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace API.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Animal, AnimalDto>().ReverseMap();
            CreateMap<AnimalDto, Animal>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Supply, SupplyDto>().ReverseMap();
            CreateMap<SupplyDto, Supply>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Land, LandDto>().ReverseMap();
            CreateMap<LandDto, Land>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Farmer, FarmerDto>().ReverseMap();
            CreateMap<FarmerDto, Farmer>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Agent, AgentDto>().ReverseMap();
            CreateMap<AgentDto, Agent>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Agency, AgencyDto>().ReverseMap();
            CreateMap<AgencyDto,Agency>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<FarmerRating, FarmerRatingDto>().ReverseMap();
            CreateMap<FarmerRatingDto, FarmerRating>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
