using Rentacar.Admin.Dto.Request;
using Rentacar.Dto;
using Rentacar.Dto.Request;
using Rentacar.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentacar.Admin.Services
{
    public class VehicleService
    {
        private static string _baseUrl = System.Configuration.ConfigurationManager.AppSettings["baseUrl"] + "api/vehicles";

        public static async Task<List<VehicleBaseDto>> FilterVehicles(VehicleRequestDto request)
        {
            var vehiclesFiltered = await HttpHelper.PostAsync<List<VehicleBaseDto>, VehicleRequestDto>(_baseUrl + "/filter", request);

            return vehiclesFiltered;
        }

        public static async Task<VehicleBaseDto> AddVehicle(NewVehicleRequest vehicle)
        {
            var newVehicle = await HttpHelper.PostAsync<VehicleBaseDto, NewVehicleRequest>($"{_baseUrl}/add", vehicle);
            return newVehicle;
        }
    }
}
