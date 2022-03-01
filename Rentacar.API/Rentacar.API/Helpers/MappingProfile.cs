﻿using AutoMapper;
using Rentacar.Dto;
using Rentacar.Entities;

namespace Rentacar.API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Booking, BookingDto>().ReverseMap();
            CreateMap<Booking, BaseBookingDto>()
                .ForMember(x => x.BookedBy, y => y.MapFrom(z => $"{z.User.FirstName} {z.User.LastName}"))
                .ForMember(x => x.VehicleModel, y => y.MapFrom(z => z.Vehicle.Model.ModelName));

            CreateMap<Review, ReviewDto>().ReverseMap();

            CreateMap<Location, LocationDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<User, BaseUserDto>()
                .ForMember(x => x.Role, y => y.MapFrom(z => z.Role.RoleName));

            CreateMap<Model, ModelDto>().ReverseMap();
            CreateMap<Model, ModelBaseDto>();
            CreateMap<Vehicle, VehicleDto>().ReverseMap();
            CreateMap<VehicleType, VehicleTypeDto>().ReverseMap();
            CreateMap<VehicleType, VehicleTypeBaseDto>();
            CreateMap<Make, MakeDto>().ReverseMap();
            CreateMap<Make, MakeBaseDto>().ReverseMap();
        }
    }
}
