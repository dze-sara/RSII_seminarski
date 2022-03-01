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

    }
}
