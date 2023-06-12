using AppEdu.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppEdu.Services
{
    public class LoginService : ILoginrepository
    {
        public async Task<object> Login(string userName, string password)
        {
            //var userInfo = new List<DirectorInfo>();

            Dictionary<string,string> datos = new Dictionary<string, string>();
            datos.Add("Usuario1", userName);
            datos.Add("Contraseña", password);

            string json = JsonConvert.SerializeObject(datos);

            StringContent typeContent = new StringContent(json,Encoding.UTF8, "application/json");

            var client = new HttpClient();
            string url = "https://dashboarddirector.sistemas19.com/api/Director/Login";

            HttpResponseMessage res = null;
            res = await client.PostAsync(url, typeContent);

            if (res.IsSuccessStatusCode)
            {
                string content = res.Content.ReadAsStringAsync().Result;
                // userInfo = JsonConvert.DeserializeObject<List<DirectorInfo>>(content);
                // return await Task.FromResult(userInfo.FirstOrDefault());
                return content;
            }
            else
            {
                return null;
            }
        }
    }
}
