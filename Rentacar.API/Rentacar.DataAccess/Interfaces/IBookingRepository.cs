using Rentacar.Dto;
using Rentacar.Dto.Request;
using Rentacar.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rentacar.DataAccess.Interfaces
{
    public interface IBookingRepository
    {
        Task<ICollection<Booking>> GetBookingsByUser(int userId);
        Task<bool> CancelBooking(int bookingId);
        Task<Booking> AddBooking(Booking booking);
        Task<List<Booking>> GetLatestActiveBookings();
        Task<List<Booking>> GetBookingHistory();
        Task<List<Booking>> GetBookingHistoryForUser(int userId);
        Task<List<Booking>> FilterBooking(BookingRequestDto bookingRequest);
        Task<List<Booking>> BookingReport(BookingReportRequestDto bookingRequest);
        Task<bool> SaveCardInfo(CardInfo cardInfo);
        Task<bool> SavePaymentInfo(PaymentInfo paymentInfo);
    }
}
