using AppEdu.Models;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace AppEdu.Services.NotasService
{
    public class NotasService : INotasRepository
    {
        public static readonly string baseUrl = "https://dashboarddirector.sistemas19.com/api";

        public async Task<IEnumerable<NotasInfo>> GetAllNotasAsync()
        {
            var NotasLista = new List<NotasInfo>();
            HttpClient Client = new HttpClient();
            string url = baseUrl + "/Director/Notas";
            Client.BaseAddress = new Uri(url);
            HttpResponseMessage respMess = await Client.GetAsync("");

            if (respMess.IsSuccessStatusCode)
            {
                NotasLista = await respMess.Content.ReadFromJsonAsync<List<NotasInfo>>();
            }
            return await Task.FromResult(NotasLista);
        }

        public async Task<bool> AddUpdateNotasAsync(NotasInfo notasIn)
        {
            string json = JsonConvert.SerializeObject(notasIn);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();

            if (notasIn.id == 0)
            {
                string url = baseUrl + "/Director/AgregarNotas";
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
                    return await Task.FromResult(true);
                }
            }
            else
            {
                string url = baseUrl + "/Director/EditarNotas";
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

        public async Task<bool> DeleteNotasAsync(int idNotas)
        {
            HttpClient client = new HttpClient();
            string url = baseUrl + "/Director/EliminarNotas/" + idNotas;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage respMess = await client.DeleteAsync("");
            if (respMess.IsSuccessStatusCode)
            {
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
