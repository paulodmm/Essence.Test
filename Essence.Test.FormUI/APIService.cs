using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Essence.Test.Web.Model;

namespace Essence.Test.FormUI
{
    public class APIService
    {
        private static string token { get; set; }

        public APIService()
        {
            this.GetToken();
        }

        public static string GetSettingsValue(string key)
        {
            var readerSettings = new System.Configuration.AppSettingsReader();
            string retorno = (string)readerSettings.GetValue(key, typeof(string));
            return retorno;
        }

        private void GetToken()
        {
            HttpClient client = InstanceClient(false);
            UserAuthDTO auth = new UserAuthDTO();
            auth.Email = GetSettingsValue("EmailAuth");
            auth.Password = GetSettingsValue("PasswordAuth");  

            HttpResponseMessage response = client.PostAsJsonAsync("api/UserAuth/login", auth).Result;
            if (response.IsSuccessStatusCode)
            {
                var product = response.Content.ReadAsStringAsync();
                UserTokenDTO tokenDTO = JsonConvert.DeserializeObject<UserTokenDTO>(product.Result);
                token = tokenDTO.Token;
            }
        }

        private static HttpClient InstanceClient()
        {
            return InstanceClient(true);
        }

        private static HttpClient InstanceClient(bool sendToken)
        {
            var readerSettings = new System.Configuration.AppSettingsReader();
            string baseURL = GetSettingsValue("URLBaseApi");

            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri(baseURL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (sendToken)
            {
                client.DefaultRequestHeaders.Authorization
                             = new AuthenticationHeaderValue("Bearer", token);
            }

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
