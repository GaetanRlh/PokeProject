using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeFiller.API.Model
{
    public class Cries
    {
        [JsonProperty("latest")]
        public string Latest {  get; set; } = string.Empty;

        [JsonProperty("legacy")]
        public string Legacy {  get; set; } = string.Empty;
    }
}
