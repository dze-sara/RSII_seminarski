using Rentacar.Dto.Request;
using Rentacar.Dto.Response;
using Rentacar.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rentacar.DataAccess.Interfaces
{
    public interface IVehicleRepository
    {
        Task<ICollection<Vehicle>> GetVehicles();
        Task<ICollection<Vehicle>> GetVehicles(List<Model> models);
        Task<Vehicle> GetVehicleById(int vehicleId);
        Task<ICollection<Vehicle>> FilterVehicles(int? tranismissionType, DateTime? bookingStartDate, DateTime? bookingEndDate, int? vehicleType);
        Task<ICollection<Vehicle>> FilterVehiclesForBooking(BookVehiclesRequest bookVehiclesRequest);

        Task<ICollection<VehicleBaseDto>> FilterVehicles(VehicleRequestDto request);
        Task<Vehicle> AddVehicle(NewVehicleRequest vehicle);
        Task<Vehicle> UpdateVehicle(int vehicleId, NewVehicleRequest vehicle);
        Task<Vehicle> GetVehicleByUserId(int userId);
        Task<bool> DeleteVehicle(int vehicleId);
        Task<List<VehiclesReportResponseDto>> VehiclesReport();
        Task<List<Review>> GetReviewsForUser(int userId);
        Task<List<Model>> GetOtherModelsReviews(List<Model> models, int userId);
        Task<List<Vehicle>> GetVehiclesByModelsId(List<int> modelIds);
    }
}
