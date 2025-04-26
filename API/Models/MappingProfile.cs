using AutoMapper;
using API.DTOs;
using API.Models;

namespace API.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserDto, User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            // Agent
            CreateMap<Agent, AgentDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email));
            CreateMap<AgentDto, Agent>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            // Farmer
            CreateMap<Farmer, FarmerDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email));
            CreateMap<FarmerDto, Farmer>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            // Agency
            CreateMap<Agency, AgencyDto>().ReverseMap();
            CreateMap<AgencyDto, Agency>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            // Animal
            CreateMap<Animal, AnimalDto>().ReverseMap();
            CreateMap<AnimalDto, Animal>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            // Supply
            CreateMap<Supply, SupplyDto>().ReverseMap();
            CreateMap<SupplyDto, Supply>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            // Land
            CreateMap<Land, LandDto>().ReverseMap();
            CreateMap<LandDto, Land>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            // FarmerRating
            CreateMap<FarmerRating, FarmerRatingDto>().ReverseMap();
            CreateMap<FarmerRatingDto, FarmerRating>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            // MarketItem
            CreateMap<MarketItem, MarketItemDto>().ReverseMap();
            CreateMap<MarketItemDto, MarketItem>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
