using Microsoft.EntityFrameworkCore;
using Rentacar.Common;
using Rentacar.DataAccess.Interfaces;
using Rentacar.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rentacar.DataAccess.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly RentacarContext _context;

        public BookingRepository(RentacarContext context)
        {
            _context = context;
        }

        public async Task<Booking> AddBooking(Booking booking)
        {
            // Validate booking
            AssertionHelper.AssertObject(booking);

            // Add booking do database
            Booking addedBooking = _context.Bookings.Add(booking).Entity;
            await _context.SaveChangesAsync();

            // Return added booking
            return addedBooking;
        }

        public async Task<bool> CancelBooking(int bookingId)
        {
            AssertionHelper.AssertInt(bookingId);

            Booking booking = await _context.Bookings.FirstOrDefaultAsync(x => x.BookingId == bookingId);

            if(booking.IsNotNull())
            {
                booking.IsCancelled = true;
                return true;
            }

            return false;
        }

        public async Task<ICollection<Booking>> GetBookingsByUser(int userId)
        {
            AssertionHelper.AssertInt(userId);

            List<Booking> bookings = await _context.Bookings
                                                   .Where(x => x.UserId == userId)
                                                   .ToListAsync();

            return bookings;
        }
    }
}
