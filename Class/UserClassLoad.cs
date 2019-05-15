using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Projekt.Api;
using Projekt.Models;
using Refit;

namespace Projekt.Class
{
    internal class UserClassLoad
    {
        private string auth = "Basic " + Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes("admin:1234"));
        private string baseUri = "https://gielda.ga/";
        public async Task<UserModel> GetUser(int username)
        {
            var nsApi = RestService.For<IGetUserInterface>(baseUri);
            var user = await nsApi.GetUser(username, auth).ConfigureAwait(false);
            return user;
        }

        public async Task<CheckStatus> PostUser(UserModel usermodel)
        {
            var nsApi = RestService.For<IPostUserInterface>(baseUri);
            var Users = await nsApi.PostUser(usermodel, auth).ConfigureAwait(false);
            return Users;
        }

        public async Task<CheckStatus> PutUser(UserModel usermodel)
        {
            var nsApi = RestService.For<IPutUserInterface>(baseUri);
            var Users = await nsApi.PutUser(usermodel, auth).ConfigureAwait(false);

            return Users;
        }

        public async Task<List<UserModel>> GetNearUsers(int userID)
        {
            var nsApi = RestService.For<IGetUsersNearInterface>(baseUri);
            var Users = await nsApi.GetUsersNear(userID, auth).ConfigureAwait(false);

            return Users;
        }
    }
}