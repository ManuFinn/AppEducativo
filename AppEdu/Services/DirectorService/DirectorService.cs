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

        public async Task<IEnumerable<DirectorInfo>> GetDirectorAsync()
        {
            var dire = new List<DirectorInfo>();
            HttpClient Client = new HttpClient();
            string url = baseUrl + "/Director/DatosDirector";
            Client.BaseAddress = new Uri(url);
            HttpResponseMessage respMess = await Client.GetAsync("");

            if (respMess.IsSuccessStatusCode)
            {
                var a = await respMess.Content.ReadAsStringAsync();
                var director = JsonConvert.DeserializeObject<DirectorInfo>(a);
                dire.Add(director);

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
                HttpResponseMessage respMess = await client.PutAsync("", content);

                if (respMess.IsSuccessStatusCode)
                {
                    await App.Current.MainPage.Navigation.PopModalAsync();
                    return await Task.FromResult(true);
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Advertencia", "Algo salio mal", "Ok");
                    return await Task.FromResult(false);
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Advertencia", "Algo salio mal", "Ok");
                return await Task.FromResult(false);
            }
        }
    }
}
