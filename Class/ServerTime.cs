using Projekt.Api;
using Projekt.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Class
{
    class ServerTime
    {
        public async Task<int> GetServerTime()
        {
            PasswordHash passwordHash = new PasswordHash();

            var auth = "Basic " + Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes("admin:1234"));
            var baseUri = "https://gielda.ga/";
            var nsApi = RestService.For<IGetServerTime>(baseUri);
            Czasmodel time = await nsApi.GetServerTime(auth).ConfigureAwait(false);
            return time.czas;
        }
    }
}
