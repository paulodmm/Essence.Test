using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Essence.Test.FormUI
{
    public class APIService
    {
        public APIService()
        {
        }

        private static HttpClient InstanceClient()
        {
            var readerSettings = new System.Configuration.AppSettingsReader();
            string baseURL = (string)readerSettings.GetValue("URLBaseApi", typeof(string));

            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri(baseURL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        public List<AmigoDTO> GetAll()
        {
            var client = InstanceClient();
            
            HttpResponseMessage response = client.GetAsync("api/Amigo/GetAll").Result;
            IEnumerable<AmigoDTO> dados = new List<AmigoDTO>();
            if (response.IsSuccessStatusCode)
            {
                var product = response.Content.ReadAsStringAsync();
                dados = JsonConvert.DeserializeObject<IEnumerable<AmigoDTO>>(product.Result);
            }

            return dados.ToList();
        }

        public List<AmigoDTO> AmigosProximos(int amigoId)
        {
            var client = InstanceClient();

            HttpResponseMessage response = client.GetAsync("api/Amigo/AmigosProximos/" + amigoId.ToString()).Result;
            IEnumerable<AmigoDTO> dados = new List<AmigoDTO>();
            if (response.IsSuccessStatusCode)
            {
                var product = response.Content.ReadAsStringAsync();
                dados = JsonConvert.DeserializeObject<IEnumerable<AmigoDTO>>(product.Result);
            }

            return dados.ToList();
        }

        public void Add(AmigoDTO amigo)
        {
            var client = InstanceClient();

            HttpResponseMessage response = client.PostAsJsonAsync("api/amigo", amigo).Result;

            if (response.IsSuccessStatusCode)
            {
            }
        }
    }
}
