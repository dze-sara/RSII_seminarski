using AutoMapper;
using Rentacar.DataAccess.Interfaces;
using Rentacar.Dto;
using Rentacar.Dto.Request;
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

        public async Task<List<BaseBookingDto>> BookingReport(BookingReportRequestDto bookingReport)
        {
            List<Booking> result = await _bookingRepository.BookingReport(bookingReport);
            return _mapper.Map<List<BaseBookingDto>>(result);
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

        public async Task<List<BaseBookingDto>> FilterBooking(BookingRequestDto bookingRequest)
        {
            List<Booking> filteredBookings = await _bookingRepository.FilterBooking(bookingRequest);
            return _mapper.Map<List<BaseBookingDto>>(filteredBookings);
        }

        public async Task<List<BaseBookingDto>> GetBookingHistory()
        {
            List<Booking> result = await _bookingRepository.GetBookingHistory();
            return _mapper.Map<List<BaseBookingDto>>(result);
        }

        public async Task<List<BaseBookingDto>> GetBookingHistoryForUser(int userId)
        {
            List<Booking> result = await _bookingRepository.GetBookingHistoryForUser(userId);
            return _mapper.Map<List<BaseBookingDto>>(result);
        }

        public async Task<ICollection<BookingDto>> GetBookingsByUser(int userId)
        {
            var bookings = await _bookingRepository.GetBookingsByUser(userId);

            return _mapper.Map<List<BookingDto>>(bookings);
        }

        public async Task<List<BaseBookingDto>> GetLatestActiveBookings()
        {
            List<Booking> result = await _bookingRepository.GetBookingHistory();
            return _mapper.Map<List<BaseBookingDto>>(result);
        }
    }
}
