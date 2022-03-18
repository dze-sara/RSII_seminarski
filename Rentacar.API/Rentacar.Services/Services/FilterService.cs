using AutoMapper;
using Rentacar.DataAccess.Interfaces;
using Rentacar.Dto;
using Rentacar.Dto.Response;
using Rentacar.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rentacar.Services.Services
{
    public class FilterService : IFilterService
    {
        private readonly IFilterRepository _filterRepository;
        private readonly IMapper _mapper;

        public FilterService(IMapper mapper, IFilterRepository filterRepository)
        {
            _filterRepository = filterRepository;
            _mapper = mapper;
        }

        public async Task<FilterLookupsDto> GetFilterLookups()
        {
            FilterLookupsDto filterLookups = new FilterLookupsDto();
            filterLookups.Makes = _mapper.Map<List<MakeBaseDto>>(await _filterRepository.GetMakesForFilter());
            filterLookups.Models = _mapper.Map<List<ModelBaseDto>>(await _filterRepository.GetModelsForFilter());
            filterLookups.VehicleTypes = _mapper.Map<List<VehicleTypeBaseDto>>(await _filterRepository.GetVehicleTypesForFilter());

            return filterLookups;
        }

        public async Task<MakeBaseDto> GetMake(string makeName)
        {
            return _mapper.Map<MakeBaseDto>(await _filterRepository.GetMake(makeName));
        }

        public async Task<List<ModelBaseDto>> GetModelsForMake(int makeId)
        {
            return _mapper.Map<List<ModelBaseDto>>(await _filterRepository.GetModelsForMake(makeId));
        }
    }
}
