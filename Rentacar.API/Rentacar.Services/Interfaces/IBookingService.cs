using Rentacar.Dto;
using Rentacar.Dto.Request;
using Rentacar.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rentacar.Services.Interfaces
{
    public interface IBookingService
    {
        Task<ICollection<BookingDto>> GetBookingsByUser(int userId);
        Task<bool> CancelBooking(int bookingId);
        Task<BookingDto> CreateBooking(BookingDto booking);
        Task<List<BaseBookingDto>> GetLatestActiveBookings();
        Task<List<BaseBookingDto>> GetBookingHistory();
        Task<List<BaseBookingDto>> GetBookingHistoryForUser(int userId);
        Task<List<BaseBookingDto>> FilterBooking(BookingRequestDto bookingRequest);
        Task<List<BaseBookingDto>> BookingReport(BookingReportRequestDto bookingReport);
    }
}
