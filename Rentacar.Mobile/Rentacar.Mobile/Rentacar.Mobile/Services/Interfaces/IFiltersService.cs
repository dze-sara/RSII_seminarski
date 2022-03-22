using Rentacar.Dto.Response;
using System.Threading.Tasks;

namespace Rentacar.Mobile.Services.Interfaces
{
    public interface IFiltersService
    {
        Task<FilterLookupsDto> GetFilterLookups();
    }
}
