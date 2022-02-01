using AutoMapper;
using Rentacar.DataAccess.Interfaces;
using Rentacar.Dto;
using Rentacar.Entities;
using Rentacar.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rentacar.Services.Services
{
    public class BookingService : IBookingService
    {
        private readonly IMapper _mapper;
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IMapper mapper, IBookingRepository bookingRepository)
        {
            _mapper = mapper;
            _bookingRepository = bookingRepository;
        }

        public async Task<bool> CancelBooking(int bookingId)
        {
            return await _bookingRepository.CancelBooking(bookingId);
        }

        public async Task<BookingDto> CreateBooking(BookingDto booking)
        {
            Booking bookingEf = _mapper.Map<Booking>(booking);
            Booking createdBooking = await _bookingRepository.AddBooking(bookingEf);
            return _mapper.Map<BookingDto>(createdBooking);
        }

        public async Task<ICollection<BookingDto>> GetBookingsByUser(int userId)
        {
            var bookings = await _bookingRepository.GetBookingsByUser(userId);

            return _mapper.Map<List<BookingDto>>(bookings);
        }
    }
}
