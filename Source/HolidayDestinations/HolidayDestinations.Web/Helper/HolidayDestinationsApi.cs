using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HolidayDestinations.Web.Helper
{
    public class HolidayDestinationsApi
    {
        public HttpClient Initialize()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:60375/")
            };
            return client;
        }
    }
}
