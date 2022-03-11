using Rentacar.Dto;
using Rentacar.Dto.Request;
using Rentacar.Dto.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rentacar.Mobile.Services.Interfaces
{
    public interface IBookingService
    {
        Task<BaseBookingDto> BookVehicle(BookingDto request);
        Task<List<BaseBookingDto>> GetBookingHistoryForUser(int userId);
    }
}
