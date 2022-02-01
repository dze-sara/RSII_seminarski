using Rentacar.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rentacar.Services.Interfaces
{
    public interface IBookingService
    {
        Task<ICollection<BookingDto>> GetBookingsByUser(int userId);
        Task<bool> CancelBooking(int bookingId);
        Task<BookingDto> CreateBooking(BookingDto booking);
    }
}
