using AppEdu.Models;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace AppEdu.Services.DocenteService
{
    public class DocenteService : IDocenteRepository
    {
        public static readonly string baseUrl = "https://dashboarddirector.sistemas19.com/api";

        public async Task<IEnumerable<DocenteInfo>> GetAllDocenteAsync()
        {
            var DocenteLista = new List<DocenteInfo>();
            HttpClient Client = new HttpClient();
            string url = baseUrl + "/Director/Docentes";
            Client.BaseAddress = new Uri(url);
            HttpResponseMessage respMess = await Client.GetAsync("");

            if (respMess.IsSuccessStatusCode)
            {
                DocenteLista = await respMess.Content.ReadFromJsonAsync<List<DocenteInfo>>();
            }
            return await Task.FromResult(DocenteLista);
        }

        public async Task<bool> AddUpdateDocenteAsync(DocenteInfo doceIn)
        {

            string json = JsonConvert.SerializeObject(doceIn);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();

            if (doceIn.Id == 0)
            {
                string url = baseUrl + "/Director/AgregarDocente";
                client.BaseAddress = new Uri(url);
                HttpResponseMessage respMess = await client.PostAsync("", content);

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
                string url = baseUrl + "/Director/EditarDocentes";
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
        }

    }
}
