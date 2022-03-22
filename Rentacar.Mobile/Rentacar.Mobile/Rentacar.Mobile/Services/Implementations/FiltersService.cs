using Rentacar.Dto.Response;
using Rentacar.Mobile.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rentacar.Mobile.Services.Implementations
{
    public class FiltersService : IFiltersService
    {
        private static string _baseUrl = HttpHelper.BaseUrl + "api/Filters";

        public async Task<FilterLookupsDto> GetFilterLookups()
        {
            return await HttpHelper.GetAsync< FilterLookupsDto>(_baseUrl);
        }
    }
}
