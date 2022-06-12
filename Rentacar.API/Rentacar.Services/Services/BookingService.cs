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
        private readonly IPaymentProcessingService _paymentProcessingService;

        public BookingService(IMapper mapper, IBookingRepository bookingRepository, IPaymentProcessingService paymentProcessingService)
        {
            _mapper = mapper;
            _bookingRepository = bookingRepository;
            _paymentProcessingService = paymentProcessingService;
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
            var paymentProcessingInfo = await _paymentProcessingService.AddPayment(booking.CardInfo, booking.TotalPrice ?? 0);
            await SaveCardInfo(booking.CardInfo);
            await SavePaymentDetails(paymentProcessingInfo);
            return _mapper.Map<BookingDto>(createdBooking);
        }

        private async Task<bool> SaveCardInfo(CardInfoDto cardInfoDto)
        {
            CardInfo cardInfoEf = _mapper.Map<CardInfo>(cardInfoDto);
            await _bookingRepository.SaveCardInfo(cardInfoEf);
            return true;
        }

        private async Task<bool> SavePaymentDetails(PaymentInfoDto paymentInfo)
        {
            PaymentInfo paymentInfoEf = _mapper.Map<PaymentInfo>(paymentInfo);
            await _bookingRepository.SavePaymentInfo(paymentInfoEf);
            return true;
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
            List<Booking> result = await _bookingRepository.GetLatestActiveBookings();
            return _mapper.Map<List<BaseBookingDto>>(result);
        }
    }
}
