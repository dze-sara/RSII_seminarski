using Rentacar.Dto.Response;
using Rentacar.Mobile.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rentacar.Mobile.Services.Implementations
{
    public class VehicleService : IVehicleService
    {
        private string _baseUrl = HttpHelper.BaseUrl + "api/Vehicles";
        public async Task<List<VehicleBaseDto>> FilterVehiclesByDateRange(DateTime startDate, DateTime endDate)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["bookingStart"] = startDate.ToString("yyyy-MM-dd hh:mm:ss");
            parameters["bookingEnd"] = endDate.ToString("yyyy-MM-dd hh:mm:ss");

            List<VehicleBaseDto> vehicles = await HttpHelper.GetAsync<List<VehicleBaseDto>>(_baseUrl + "/filter", parameters);
            return vehicles;
        }

        public async Task<List<VehicleBaseDto>> GetRecommendedVehicles(int userId)
        {
            List<VehicleBaseDto> vehicles = await HttpHelper.GetAsync<List<VehicleBaseDto>>(_baseUrl + "/recommended/" + userId.ToString());
            return vehicles;
        }
    }
}
