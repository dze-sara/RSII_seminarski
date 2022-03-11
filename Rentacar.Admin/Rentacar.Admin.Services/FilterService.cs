using Rentacar.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentacar.Admin.Services
{
    public static class FilterService
    {
        private static string _baseUrl = System.Configuration.ConfigurationManager.AppSettings["baseUrl"] + "api/filters";

        public async static Task<FilterLookupsDto> GetFilterLookups()
        {
            return await HttpHelper.GetAsync<FilterLookupsDto>(_baseUrl);
        }

        public async static Task<List<ModelBaseDto>> GetModelsForMake(int id)
        {
            var res = await HttpHelper.GetAsync<List<ModelBaseDto>>(_baseUrl+$"/models/{id}");
            return res;
        }

    }
}
