using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace PokeFiller.API
{
    public class APIHelper
    {
        public static HttpClient? Client { get; set; }

        public static void Initialize()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("https://pokeapi.co/api/v2/pokemon/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
