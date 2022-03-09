using Microsoft.EntityFrameworkCore;
using Rentacar.Common;
using Rentacar.DataAccess.Interfaces;
using Rentacar.Dto;
using Rentacar.Dto.Request;
using Rentacar.Entities;
using System;
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
            //AssertionHelper.AssertInt(bookingId);

            //Booking booking = await _context.Bookings.FirstOrDefaultAsync(x => x.BookingId == bookingId);

            //if(booking.IsNotNull())
            //{
            //    booking.IsCancelled = true;
            //    return true;
            //}

            return false;
        }

        public async Task<List<Booking>> FilterBooking(BookingRequestDto bookingRequest)
        {
            var bookingsQuery = _context.Bookings
                                 .Include(x => x.Vehicle)
                                 .ThenInclude(y => y.Model)
                                 .Include(x => x.User)
                                 .AsQueryable();

            if (bookingRequest.StartDate != null)
            {
                bookingsQuery = bookingsQuery.Where(x => x.StartDate >= bookingRequest.StartDate);
            }

            if (bookingRequest.EndDate != null)
            {
                bookingsQuery = bookingsQuery.Where(x => x.EndDate <= bookingRequest.EndDate);
            }

            if (bookingRequest.BookingId > 0)
            {
                bookingsQuery = bookingsQuery.Where(x => x.BookingId == bookingRequest.BookingId);
            }

            if (bookingRequest.UserId > 0)
            {
                bookingsQuery = bookingsQuery.Where(x => x.UserId == bookingRequest.UserId);
            }

            if (!string.IsNullOrEmpty(bookingRequest.Model))
            {
                bookingsQuery = bookingsQuery.Where(x => x.Vehicle.Model.ModelName == bookingRequest.Model);
            }

            if (!string.IsNullOrEmpty(bookingRequest.Make))
            {
                bookingsQuery = bookingsQuery.Where(x => x.Vehicle.Model.Make.MakeName == bookingRequest.Make);
            }

            if (bookingRequest.VehicleId > 0)
            {
                bookingsQuery = bookingsQuery.Where(x => x.VehicleId == bookingRequest.VehicleId);
            }

            if (bookingRequest.MinPrice > 0)
            {
                bookingsQuery = bookingsQuery.Where(x => x.TotalPrice >= bookingRequest.MinPrice);
            }

            if (bookingRequest.MaxPrice > 0)
            {
                bookingsQuery = bookingsQuery.Where(x => x.TotalPrice <= bookingRequest.MaxPrice);
            }

            return await bookingsQuery.ToListAsync();
        }

        public async Task<List<Booking>> GetBookingHistory()
        {
            return await _context.Bookings
                                 .Include(x => x.Vehicle)
                                 .ThenInclude(y => y.Model)
                                 .Include(x => x.User)
                                 .Where(x => x.StartDate < DateTime.UtcNow && x.EndDate < DateTime.UtcNow)
                                 .OrderByDescending(x => x.EndDate)
                                 .ToListAsync();
        }

        public async Task<ICollection<Booking>> GetBookingsByUser(int userId)
        {
            AssertionHelper.AssertInt(userId);

            List<Booking> bookings = await _context.Bookings
                                                   .Where(x => x.UserId == userId)
                                                   .ToListAsync();

            return bookings;
        }

        public async Task<List<Booking>> GetLatestActiveBookings()
        {
            return await _context.Bookings
                                 .Include(x => x.Vehicle)
                                 .ThenInclude(y => y.Model)
                                 .Include(x => x.User)
                                 .Where(x => x.StartDate < DateTime.UtcNow && x.EndDate > DateTime.UtcNow)
                                 .OrderByDescending(x => x.EndDate)
                                 .ToListAsync();
        }
    }
}
