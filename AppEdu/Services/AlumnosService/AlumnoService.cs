using AppEdu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AppEdu.Services.AlumnosService
{
    public class AlumnoService : IAlumnoReository
    {
        public static readonly string baseUrl = "https://dashboarddirector.sistemas19.com/api";

        public async Task<IEnumerable<AlumnosInfo>> GetAllAlumnosAsync()
        {
            var AlumnosLista = new List<AlumnosInfo>();
            HttpClient Client = new HttpClient();
            string url = baseUrl + "/Director/Alumnos";
            Client.BaseAddress = new Uri(url);
            HttpResponseMessage respMess = await Client.GetAsync("");

            if (respMess.IsSuccessStatusCode)
            {
                AlumnosLista = await respMess.Content.ReadFromJsonAsync<List<AlumnosInfo>>();
            }
            return await Task.FromResult(AlumnosLista);
        }
    }
}
