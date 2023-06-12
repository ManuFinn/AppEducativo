using AppEdu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AppEdu.Services.MateriaService
{
    public class MateriaService : IMateriaRepository
    {
        public static readonly string baseUrl = "https://dashboarddirector.sistemas19.com/api";

        public async Task<IEnumerable<MateriasInfo>> GetAllMateriasAsync()
        {
            var MateriasLista = new List<MateriasInfo>();
            HttpClient Client = new HttpClient();
            string url = baseUrl + "/Director/Materias";
            Client.BaseAddress = new Uri(url);
            HttpResponseMessage respMess = await Client.GetAsync("");

            if (respMess.IsSuccessStatusCode)
            {
                MateriasLista = await respMess.Content.ReadFromJsonAsync<List<MateriasInfo>>();
            }
            return await Task.FromResult(MateriasLista);
        }
    }
}
