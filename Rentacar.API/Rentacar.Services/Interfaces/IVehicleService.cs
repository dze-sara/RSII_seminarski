using Rentacar.Dto;
using Rentacar.Dto.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rentacar.Services.Interfaces
{
    public interface IVehicleService
    {
        Task<ICollection<VehicleDto>> GetVehicles();
        Task<VehicleDto> GetVehicleById(int vehicleId);
        Task<ICollection<VehicleDto>> FilterVehicles(TransmissionTypeEnum? tranismissoinType, DateTime? bookingStartDate, DateTime? bookingEndDate, int? vehicleType);
    }
}
