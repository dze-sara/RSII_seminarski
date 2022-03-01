using AutoMapper;
using Rentacar.Dto;
using Rentacar.Entities;

namespace Rentacar.API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Booking, BookingDto>().ReverseMap();
            CreateMap<Review, ReviewDto>().ReverseMap();

            CreateMap<Location, LocationDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<User, BaseUserDto>()
                .ForMember(x => x.Role, y => y.MapFrom(z => z.Role.RoleName));

            CreateMap<Model, ModelDto>().ReverseMap();
            CreateMap<Vehicle, VehicleDto>().ReverseMap();
            CreateMap<VehicleType, VehicleTypeDto>().ReverseMap();
            CreateMap<Make, MakeDto>().ReverseMap();
        }
    }
}
