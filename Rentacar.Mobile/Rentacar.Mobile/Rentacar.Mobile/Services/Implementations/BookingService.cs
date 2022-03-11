using Rentacar.Dto;
using Rentacar.Dto.Request;
using Rentacar.Dto.Response;
using Rentacar.Mobile.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rentacar.Mobile.Services
{
    public class BookingService : IBookingService
    {
        private static string _baseUrl = HttpHelper.BaseUrl + "api/Bookings";

        public async Task<List<BaseBookingDto>> GetBookingHistoryForUser(int userId)
        {
            var bookingHistoryResponse = await HttpHelper.GetAsync<List<BaseBookingDto>>(_baseUrl + "/history/" + userId.ToString());

            return bookingHistoryResponse;
        }

        public async Task<BaseBookingDto> BookVehicle(BookingDto request)
        {
            var bookVehileResponse = await HttpHelper.PostAsync<BaseBookingDto, BookingDto>(_baseUrl, request);

            return bookVehileResponse;
        }
    }
}
