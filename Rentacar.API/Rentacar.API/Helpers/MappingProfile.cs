using AutoMapper;
using Rentacar.Dto;
using Rentacar.Dto.Response;
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
                .ForMember(x => x.ImageUrl, y=> y.MapFrom(z => z.Vehicle.ImageUrl))
                .ForMember(x => x.NumberOfSeats, y => y.MapFrom(z => z.Vehicle.Model.NoOfSeats))
                .ForMember(x => x.TransmissionType, y => y.MapFrom(z => z.Vehicle.TransmissionType))
                .ForMember(x => x.VehicleType, y => y.MapFrom(z => z.Vehicle.Model.VehicleType.VehicleTypeName))
                .ForMember(x => x.CanAddReview, y => y.MapFrom(z => !z.ReviewAdded))
                .ForMember(x => x.ModelId, y => y.MapFrom(z => z.Vehicle.ModelId))
                .ForMember(x => x.VehicleModel, y => y.MapFrom(z => z.Vehicle.Model.ModelName));

            CreateMap<Review, ReviewDto>()
                .ForMember(x => x.AuthorName, y => y.MapFrom(z => $"{z.User.FirstName} {z.User.LastName}"));

            CreateMap<ReviewDto, Review>();

            CreateMap<Location, LocationDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<User, BaseUserDto>()
                .ForMember(x => x.Role, y => y.MapFrom(z => z.Role.RoleName));

            CreateMap<Model, ModelDto>().ReverseMap();
            CreateMap<Model, ModelBaseDto>();
            CreateMap<Vehicle, VehicleDto>().ReverseMap();
            CreateMap<Vehicle, VehicleBaseDto>()
                .ForMember(x => x.Make, y => y.MapFrom(z => z.Model.Make.MakeName))
                .ForMember(x => x.Model, y => y.MapFrom(z => z.Model.ModelName))
                .ForMember(x => x.NumberOfSeats, y => y.MapFrom(z => z.Model.NoOfSeats))
                .ForMember(x => x.VehicleType, y => y.MapFrom(z => z.Model.VehicleType.VehicleTypeName));
            CreateMap<VehicleType, VehicleTypeDto>().ReverseMap();
            CreateMap<VehicleType, VehicleTypeBaseDto>();
            CreateMap<Make, MakeDto>().ReverseMap();
            CreateMap<Make, MakeBaseDto>().ReverseMap();

            CreateMap<PaymentInfo, PaymentInfoDto>().ReverseMap();
            CreateMap<CardInfo, CardInfoDto>().ReverseMap();
        }
    }
}
