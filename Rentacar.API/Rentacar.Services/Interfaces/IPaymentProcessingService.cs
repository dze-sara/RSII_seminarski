using Rentacar.Dto;
using System.Threading.Tasks;

namespace Rentacar.Services.Interfaces
{
    public interface IPaymentProcessingService
    {
        Task<bool> AddPayment(CardInfoDto cardInfo, decimal amount);
    }
}
