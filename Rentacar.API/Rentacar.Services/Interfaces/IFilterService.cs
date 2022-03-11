using Rentacar.Dto;
using Rentacar.Dto.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rentacar.Services.Interfaces
{
    public interface IFilterService
    {
        public Task<FilterLookupsDto> GetFilterLookups();
        public Task<List<ModelBaseDto>> GetModelsForMake(int makeId);
    }
}
