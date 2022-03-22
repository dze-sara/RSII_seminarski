using Rentacar.Dto;
using Rentacar.Dto.Enums;
using Rentacar.Dto.Request;
using Rentacar.Dto.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rentacar.Services.Interfaces
{
    public interface IVehicleService
    {
        Task<ICollection<VehicleDto>> GetVehicles();
        Task<VehicleDto> GetVehicleById(int vehicleId);
        Task<ICollection<VehicleBaseDto>> FilterVehicles(TransmissionTypeEnum? tranismissoinType, DateTime? bookingStartDate, DateTime? bookingEndDate, int? vehicleType);
        Task<ICollection<VehicleBaseDto>> FilterVehiclesForBooking(BookVehiclesRequest bookVehiclesRequest);
        Task<ICollection<VehicleBaseDto>> FilterVehicles(VehicleRequestDto request);
        Task<VehicleBaseDto> AddVehicle(NewVehicleRequest vehicle);
        Task<ICollection<VehicleBaseDto>> GetRecommendedVehicles(int userId);
        Task<VehicleBaseDto> UpdateVehicle(int vehicleId, NewVehicleRequest request);
        Task<bool> DeleteVehicle(int vehicleId);
        Task<List<VehiclesReportResponseDto>> VehiclesReport();
        Task<ICollection<VehicleBaseDto>> GetRecommendationsForUser(int userId);

    }
}
