using AppEdu.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AppEdu.Services.CalendarioService
{
    public class CalendarioService : ICalendarioRepository
    {
        public static readonly string baseUrl = "https://dashboarddirector.sistemas19.com/api";

        public async Task<IEnumerable<CalendarioInfo>> GetAllCalendariosAsync()
        {
            var CalendarioLista = new List<CalendarioInfo>();
            HttpClient Client = new HttpClient();
            string url = baseUrl + "/Director/Calendario";
            Client.BaseAddress = new Uri(url);
            HttpResponseMessage respMess = await Client.GetAsync("");

            if (respMess.IsSuccessStatusCode)
            {
                CalendarioLista = await respMess.Content.ReadFromJsonAsync<List<CalendarioInfo>>();
            }
            return await Task.FromResult(CalendarioLista);
        }

        public async Task<bool> AddUpdateCalendarioAsync(CalendarioInfo caleInfo)
        {
            var fecha = "";
            string input = caleInfo.fecha;
            string format = "dd-MMM-yy h:mm:ss tt";

            if (DateTime.TryParseExact(input, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDateTime))
            {
                string modifiedFormat = "yyyy-MM-dd";
                string modifiedOutput = parsedDateTime.ToString(modifiedFormat);
                fecha = modifiedOutput;
            }
            caleInfo.fecha = fecha;
            string json = JsonConvert.SerializeObject(caleInfo);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();

            if (caleInfo.idCalendario == 0)
            {
                string url = baseUrl + "/Director/AgregarEvento";
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
                string url = baseUrl + "/Director/EditarEvento";
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

        public async Task<bool> DeleteCalendarioAsync(int idCale)
        {
            HttpClient client = new HttpClient();
            string url = baseUrl + "/Director/EliminarEvento/" + idCale;
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
