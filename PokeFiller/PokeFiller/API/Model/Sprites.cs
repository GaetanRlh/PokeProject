using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeFiller.API.Model
{
    public class Sprites
    {
        [JsonProperty("front_default")]
        public string Front_default { get; set; } = string.Empty;
    }
}
