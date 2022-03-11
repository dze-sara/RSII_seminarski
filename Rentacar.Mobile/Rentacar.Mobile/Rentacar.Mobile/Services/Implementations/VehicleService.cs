using Rentacar.Dto.Response;
using Rentacar.Mobile.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rentacar.Mobile.Services.Implementations
{
    public class VehicleService : IVehicleService
    {
        private string _baseUrl = HttpHelper.BaseUrl + "api/vehicles";
        public async Task<List<VehicleBaseDto>> FilterVehiclesByDateRange(DateTime startDate, DateTime endDate)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["startDate"] = startDate.ToString();
            parameters["endDate"] = endDate.ToString();

            List<VehicleBaseDto> vehicles = await HttpHelper.GetAsync<List<VehicleBaseDto>>(_baseUrl + "/filter", parameters);
            return vehicles;
        }
    }
}
