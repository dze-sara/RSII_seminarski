using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Rentacar.Admin.Services
{
    public static class HttpHelper
    {
        public static string BuildQueryParams(string baseUrl, Dictionary<string, string> parameters)
        {
            var builder = new UriBuilder(baseUrl)
            {
                Port = -1
            };
            var query = HttpUtility.ParseQueryString(builder.Query);

            foreach (var parameter in parameters)
            {
                query[parameter.Key] = parameter.Value;
            }

            builder.Query = query.ToString();

            return builder.ToString();
        }
    }
}
