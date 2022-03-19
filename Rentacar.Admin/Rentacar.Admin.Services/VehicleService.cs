using Rentacar.Admin.Dto;
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

        public static async Task<bool> DeleteVehicle(int vehicleId)
        {
            var deleted = await HttpHelper.DeleteAsync<bool>($"{_baseUrl}/{vehicleId}");
            return deleted;
        }

        public static async Task<VehicleBaseDto> UpdateVehicle(int vehicleId, NewVehicleRequest vehicle)
        {
            var newVehicle = await HttpHelper.PostAsync<VehicleBaseDto, NewVehicleRequest>($"{_baseUrl}/update/{vehicleId}", vehicle);
            return newVehicle;
        }

        public static async Task<List<VehiclesReportResponseDto>> VehiclesReport()
        {
            var vehiclesReport = await HttpHelper.GetAsync<List<VehiclesReportResponseDto>>($"{_baseUrl}/report");
            return vehiclesReport;
        }

        public static List<VehiclesReportDataDto> PrepareVehicleReportDataChart(List<VehiclesReportResponseDto> vehiclesReport)
        {
            var response = new List<VehiclesReportDataDto>();
            foreach (var item in vehiclesReport)
            {
                double hours = 0;
                foreach (var booking in item.BookingsForVehicle)
                {
                    hours += (booking.EndDate - booking.StartDate).TotalHours;
                }

                var data = new VehiclesReportDataDto()
                {
                    VehicleName = $"{item.VehicleBase.Make} {item.VehicleBase.Model}",
                    TotalHours = (int)hours
                };
                response.Add(data);
            }
            return response;
        }

        public static List<VehiclesReportDataTableDto> PrepareVehicleReportDataTable(List<VehiclesReportResponseDto> vehiclesReport)
        {
            var response = new List<VehiclesReportDataTableDto>();
            foreach (var item in vehiclesReport)
            {
                double hours = 0;
                foreach (var booking in item.BookingsForVehicle)
                {
                    hours += (booking.EndDate - booking.StartDate).TotalHours;
                }

                var data = new VehiclesReportDataTableDto()
                {
                    VehicleId = item.VehicleBase.VehicleId,
                    Make = item.VehicleBase.Make,
                    Model = item.VehicleBase.Model,
                    PricePerDay = item.VehicleBase.RatePerDay,
                    TotalHoursBooked = hours,
                    TotalPrice = hours * (double)item.VehicleBase.RatePerDay
                };
                response.Add(data);
            }

            return response;
        }
    }
}
