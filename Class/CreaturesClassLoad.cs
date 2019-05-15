using Projekt.Api;
using Projekt.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Class
{
    class CreaturesClassLoad
    {

        private string auth = "Basic " + Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes("admin:1234"));
        private string baseUri = "https://gielda.ga/";
        public async Task<List<CreaturesInfo>> GetCreature(CreaturesInfo creaturesInfo)
        {
            var nsApi = RestService.For<IGetCreatureInfo>(baseUri);
            var x = await nsApi.GetCreatureInfo(creaturesInfo, auth).ConfigureAwait(false);

            return x;
        }

        public async Task<CheckStatus> PutCreature(Creaturesmodel creaturesmodel)
        {
            var nsApi = RestService.For<IPutCreature>(baseUri);
            var x = await nsApi.PutUserCreatures(creaturesmodel, auth).ConfigureAwait(false);
            return x;
        }

        public async Task<CheckStatus> PostCreature(Creaturesmodel creaturesmodel)
        {
            var nsApi = RestService.For<IPostCreature>(baseUri);
            var x = await nsApi.PostUserCreatures(creaturesmodel, auth).ConfigureAwait(false);
            return x;
        }

        public async Task<List<Creaturesmodel>> GetUserCreatures(Creaturesmodel creaturesmodel)
        {
            var nsApi = RestService.For<IGetUserCreatures>(baseUri);
            List<Creaturesmodel> x = await nsApi.GetUserCreaturesI(creaturesmodel, auth).ConfigureAwait(false);
            return x;
        }
    }
}
