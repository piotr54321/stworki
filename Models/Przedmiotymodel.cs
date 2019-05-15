using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt.Models
{
    class Przedmiotymodel
    {
        [JsonProperty("id_przedmiotu")]
        public string id_przedmiotu { get; set; }

        [JsonProperty("nazwa")]
        public string nazwa { get; set; }

        [JsonProperty("fotografia")]
        public string fotografia { get; set; }

        [JsonProperty("cena")]
        public string cena { get; set; }

        [JsonProperty("nazwa_kategorii")]
        public string nazwa_kategorii { get; set; }

        [JsonProperty("code")]
        public string code { get; set; }
    }

    public class Plecakmodel
    {

        [JsonProperty("user_id")]
        public string user_id { get; set; }

        [JsonProperty("id_przedmiotu")]
        public string id_przedmiotu { get; set; }

        [JsonProperty("ilosc")]
        public string ilosc { get; set; }

        [JsonProperty("nazwa")]
        public string nazwa { get; set; }

        [JsonProperty("fotografia")]
        public string fotografia { get; set; }

        [JsonProperty("cena")]
        public string cena { get; set; }

        [JsonProperty("nazwa_kategorii")]
        public string nazwa_kategorii { get; set; }

        [JsonProperty("code")]
        public string code { get; set; }

        [JsonProperty("znak")]
        public string znak { get; set; }
    }
}
