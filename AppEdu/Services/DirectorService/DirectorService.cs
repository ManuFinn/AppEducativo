using AppEdu.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AppEdu.Services.DirectorService
{
    public class DirectorService : IDirectorRepository
    {
        public static readonly string baseUrl = "https://dashboarddirector.sistemas19.com/api";

        public async Task<DirectorInfo> GetDirectorAsync()
        {
            var dire = new DirectorInfo();
            HttpClient Client = new HttpClient();
            string url = baseUrl + "/Director/DatosDirector";
            Client.BaseAddress = new Uri(url);
            HttpResponseMessage respMess = await Client.GetAsync("");

            if (respMess.IsSuccessStatusCode)
            {
                var content = await respMess.Content.ReadAsStringAsync();
                dire = JsonConvert.DeserializeObject<DirectorInfo>(content);
            }
            return await Task.FromResult(dire);
        }

        public async Task<bool> UpdateDirectorAsync(DirectorInfo direIn)
        {
            string json = JsonConvert.SerializeObject(direIn);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();

            if (direIn.id != 0)
            {
                string url = baseUrl + "/Director/EditarMiPerfil";
                client.BaseAddress = new Uri(url);
                HttpResponseMessage respMess = await client.PostAsync("", content);

                if (respMess.IsSuccessStatusCode)
                {
                    return await Task.FromResult(true);
                }
            }
            return await Task.FromResult(true);
        }
    }
}
