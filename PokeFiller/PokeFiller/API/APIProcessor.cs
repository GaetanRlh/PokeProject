using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeFiller.API
{
    public class APIProcessor
    {
        public static Task<Data> Load(int id)
        {
            string url = $"{id}";

            using(Task<HttpResponseMessage> response = APIHelper.Client!.GetAsync(url))
            {
                if (response.Result.IsSuccessStatusCode)
                {
                    Task<Data> data = response.Result.Content.ReadAsAsync<Data>();
                    return data;
                }
                else throw new Exception(response.Result.ReasonPhrase);
            }
        }
    }
}
