using AppEdu.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AppEdu.Services.DocenteMateriaService
{
    public class DocenteMateriaService : IDocenteMateriaRepository
    {
        public static readonly string baseUrl = "https://dashboarddirector.sistemas19.com/api";

        public async Task<IEnumerable<DocenteMateria>> GetAllDocenteMateriasAsync()
        {
            var DocenteMateriaLista = new List<DocenteMateria>();
            HttpClient Client = new HttpClient();
            string url = baseUrl + "/Director/DocenteMateria";
            Client.BaseAddress = new Uri(url);
            HttpResponseMessage respMess = await Client.GetAsync("");

            if (respMess.IsSuccessStatusCode)
            {
                DocenteMateriaLista = await respMess.Content.ReadFromJsonAsync<List<DocenteMateria>>();
            }
            return await Task.FromResult(DocenteMateriaLista);
        }

        public async Task<bool> AddUpdateDocenteMateriaAsync(DocenteMateria doceMate)
        {
            string json = JsonConvert.SerializeObject(doceMate);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();

            if (doceMate.idDocente != 0)
            {
                string url = baseUrl + "/Director/AsignarMateriasEspeciales";
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
