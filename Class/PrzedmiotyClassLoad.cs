using Projekt.Api;
using Projekt.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Class
{
    class PrzedmiotyClassLoad
    {

        private string auth = "Basic " + Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes("admin:1234"));
        private string baseUri = "https://gielda.ga/";
        public async Task<List<Przedmiotymodel>> GetPrzedmiotymodel(Przedmiotymodel przedmiotymodel)
        {
            var nsApi = RestService.For<IGetPrzedmioty>(baseUri);
            var user = await nsApi.GetPrzedmiotymodel(przedmiotymodel, auth).ConfigureAwait(false);
            return user;
        }

        public async Task<List<Plecakmodel>> GetPlecakmodel(Plecakmodel plecakmodel)
        {
            var nsApi = RestService.For<IGetPlecak>(baseUri);
            var user = await nsApi.GetPlecakmodel(plecakmodel, auth).ConfigureAwait(false);
            return user;
        }

        public async Task<CheckStatus> PostPlecakmodel(Plecakmodel plecakmodel)
        {
            var nsApi = RestService.For<IPostPlecak>(baseUri);
            var user = await nsApi.PostPlecakmodel(plecakmodel, auth).ConfigureAwait(false);
            return user;
        }
    }

}
