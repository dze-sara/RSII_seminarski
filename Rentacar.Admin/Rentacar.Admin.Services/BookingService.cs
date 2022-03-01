using Rentacar.Dto;
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
    }
}
