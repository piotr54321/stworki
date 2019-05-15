using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt.Models
{
    public class Creaturesmodel
    {
        [JsonProperty("code")]
        public string code { get; set; }

        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("users_id")]
        public string users_id { get; set; }

        [JsonProperty("current")]
        public string current { get; set; }

        [JsonProperty("health")]
        public string health { get; set; }

        [JsonProperty("happy")]
        public string happy { get; set; }

        [JsonProperty("hungry")]
        public string hungry { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("createtime")]
        public string createtime { get; set; }

        [JsonProperty("creatures_id")]
        public string creatures_id { get; set; }

        [JsonProperty("fav_item")]
        public string fav_item { get; set; }
    }

    public class CreaturesInfo
    {
        [JsonProperty("code")]
        public string code { get; set; }

        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("image")]
        public string image { get; set; }

        [JsonProperty("sex")]
        public string sex { get; set; }
    }
}
