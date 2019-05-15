using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt.Models
{
    public class Czasmodel
    {
        [JsonProperty("czas")]
        public int czas { get; set; }
    }
}
