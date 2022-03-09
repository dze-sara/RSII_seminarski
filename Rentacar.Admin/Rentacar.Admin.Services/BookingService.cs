using Rentacar.Dto;
using Rentacar.Dto.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rentacar.Admin.Services
{
    public static class BookingService
    {
        private static string _baseUrl = System.Configuration.ConfigurationManager.AppSettings["baseUrl"] + "api/bookings";

        public static async Task<List<BaseBookingDto>> GetActiveBookings()
        {
            var activeBookingsResponse = await HttpHelper.GetAsync<List<BaseBookingDto>>(_baseUrl + "/active");

            return activeBookingsResponse;
        }

        public static async Task<List<BaseBookingDto>> GetBookingHistory()
        {
            var bookingHistoryResponse = await HttpHelper.GetAsync<List<BaseBookingDto>>(_baseUrl + "/history");

            return bookingHistoryResponse;
        }

        public static async Task<List<BaseBookingDto>> FilterBookings(BookingRequestDto request)
        {
            var bookingHistoryResponse = await HttpHelper.PostAsync<List<BaseBookingDto>, BookingRequestDto>(_baseUrl + "/filter", request);

            return bookingHistoryResponse;
        }
    }
}
