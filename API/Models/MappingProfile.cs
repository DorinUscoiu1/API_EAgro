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

            CreateMap<Agent, AgentDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email));

            CreateMap<Farmer, FarmerDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email));

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

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserDto, User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
