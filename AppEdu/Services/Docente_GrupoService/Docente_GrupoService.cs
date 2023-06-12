using AppEdu.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AppEdu.Services.Docente_GrupoService
{
    public class Docente_GrupoService : IDocente_GrupoRepository
    {
        public static readonly string baseUrl = "https://dashboarddirector.sistemas19.com/api";

        public async Task<IEnumerable<Docente_Grupo>> GetAllDocenteGruposAsync()
        {
            var DocenteGrupoLista = new List<Docente_Grupo>();
            HttpClient Client = new HttpClient();
            string url = baseUrl + "/Director/DocenteGrupo";
            Client.BaseAddress = new Uri(url);
            HttpResponseMessage respMess = await Client.GetAsync("");

            if (respMess.IsSuccessStatusCode)
            {
                DocenteGrupoLista = await respMess.Content.ReadFromJsonAsync<List<Docente_Grupo>>();
            }
            return await Task.FromResult(DocenteGrupoLista);
        }

        public async Task<bool> AddUpdateDocenteAsync(Docente_Grupo docegruIn)
        {
            string json = JsonConvert.SerializeObject(docegruIn);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();

            if (docegruIn.Id == 0)
            {
                string url = baseUrl + "/Director/AsignarGrupos";
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
