using Rentacar.Dto.Response;
using System.Threading.Tasks;

namespace Rentacar.Services.Interfaces
{
    public interface IFilterService
    {
        public Task<FilterLookupsDto> GetFilterLookups();
    }
}
