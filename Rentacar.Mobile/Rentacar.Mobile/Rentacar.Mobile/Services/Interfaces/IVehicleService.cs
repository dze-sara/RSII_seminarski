using Rentacar.Dto.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rentacar.Mobile.Services.Interfaces
{
    public interface IVehicleService
    {
        Task<List<VehicleBaseDto>> FilterVehiclesByDateRange(DateTime startDate, DateTime endTime);
        Task<List<VehicleBaseDto>> GetRecommendedVehicles(int userId);
    }
}
