using Newtonsoft.Json;

namespace Projekt.Models
{
    public class UserModel
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("username")]
        public string username { get; set; }

        [JsonProperty("newusername")]
        public string newusername { get; set; }

        [JsonProperty("password")]
        public string password { get; set; }

        [JsonProperty("registertime")]
        public string registertime { get; set; }

        [JsonProperty("online")]
        public string online { get; set; }

        [JsonProperty("coins")]
        public string coins { get; set; }

        [JsonProperty("code")]
        public string code { get; set; }

        [JsonProperty("email")]
        public string email { get; set; }

        [JsonProperty("longitude")]
        public string longitude { get; set; }

        [JsonProperty("latitude")]
        public string latitude { get; set; }

        [JsonProperty("fighttime")]
        public string fighttime { get; set; }

        [JsonProperty("fightid")]
        public string fightid { get; set; }

    }

    public class CheckPasswordModel
    {
        public bool correctPassword { get; set; }
        public string id { get; set; }
        public int code { get; set; }
    }

    public class CheckStatus
    {
        [JsonProperty("code")]
        public string code { get; set; }

        [JsonProperty("id")]
        public string id { get; set; }
    }
}