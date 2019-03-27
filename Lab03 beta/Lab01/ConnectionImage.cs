using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.ComponentModel;

namespace Lab01
{
    class ConnectionImage
    {
        static string urlImg = "https://some-random-api.ml/dogimg";

   /*
        public static async Task<string> LoadImage()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage resImg = await client.GetAsync(urlImg) ;
            resImg.EnsureSuccessStatusCode();
            string responseBodyImg = await resImg.Content.ReadAsStringAsync();

            return await responseBodyImg;
        }
    */

    }
}
