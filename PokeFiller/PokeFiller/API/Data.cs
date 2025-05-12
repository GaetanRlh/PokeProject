using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PokeFiller.API.Model;

namespace PokeFiller.API
{
    public class Data
    {
        [JsonProperty("sprites")]
        public Sprites Sprites { get; set; } = new Sprites();

        [JsonProperty("cries")]
        public Cries Cries { get; set; } = new Cries();

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
