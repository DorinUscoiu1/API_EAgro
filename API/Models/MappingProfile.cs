using AutoMapper;
using API.DTOs;
using API.Models;

namespace API.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserDto, User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Agent, AgentDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email));
            CreateMap<AgentDto, Agent>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Farmer, FarmerDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email));
            CreateMap<FarmerDto, Farmer>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Agency, AgencyDto>().ReverseMap();
            CreateMap<AgencyDto, Agency>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Animal, AnimalDto>().ReverseMap();
            CreateMap<AnimalDto, Animal>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Supply, SupplyDto>().ReverseMap();
            CreateMap<SupplyDto, Supply>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Land, LandDto>().ReverseMap();
            CreateMap<LandDto, Land>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<FarmerRating, FarmerRatingDto>().ReverseMap();
            CreateMap<FarmerRatingDto, FarmerRating>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<MarketItem, MarketItemDto>().ReverseMap();
            CreateMap<MarketItemDto, MarketItem>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<LandFundingRequest, LandFundingRequestDto>().ReverseMap();
            CreateMap<LandFundingRequestDto, LandFundingRequest>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<FarmerSupply, FarmerSupplyDto>();
            CreateMap<PaymentScheme, PaymentSchemeDto>().ReverseMap();
            CreateMap<PaymentSchemeDto, PaymentScheme>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<AnimalPaymentScheme, AnimalPaymentSchemeDto>().ReverseMap();
            CreateMap<AnimalPaymentSchemeDto, AnimalPaymentScheme>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<AnimalFundingRequest, AnimalFundingRequestDto>().ReverseMap();
            CreateMap<AnimalFundingRequestDto, AnimalFundingRequest>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

        }
    }
}
