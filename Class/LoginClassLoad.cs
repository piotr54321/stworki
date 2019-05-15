using System;
using System.Text;
using System.Threading.Tasks;
using Projekt.Api;
using Projekt.Models;
using Refit;
using Projekt.Class;

namespace Projekt.Class
{
    internal class LoginClassLoad
    {
        public async Task<CheckStatus> CheckPass(string username, string password)
        {
            PasswordHash passwordHash = new PasswordHash();

            var auth = "Basic " + Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes("admin:1234"));
            var baseUri = "https://gielda.ga/";
            var nsApi = RestService.For<IPasswordInterface>(baseUri);
            var pass = await nsApi.GetCheckPassword(username, password, auth).ConfigureAwait(false);
            return pass;
        }
    }
}