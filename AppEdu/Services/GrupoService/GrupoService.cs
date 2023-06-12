using AppEdu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AppEdu.Services.GrupoService
{
    public class GrupoService : IGrupoRepository
    {
        public static readonly string baseUrl = "https://dashboarddirector.sistemas19.com/api";

        public async Task<IEnumerable<GruposInfo>> GetAllGruposAsync()
        {
            var GrupoLista = new List<GruposInfo>();
            HttpClient Client = new HttpClient();
            string url = baseUrl + "/Director/DocenteGrupo";
            Client.BaseAddress = new Uri(url);
            HttpResponseMessage respMess = await Client.GetAsync("");

            if (respMess.IsSuccessStatusCode)
            {
                GrupoLista = await respMess.Content.ReadFromJsonAsync<List<GruposInfo>>();
            }
            return await Task.FromResult(GrupoLista);
        }
        
    }
}
