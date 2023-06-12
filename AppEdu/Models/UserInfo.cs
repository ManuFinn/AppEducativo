using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEdu.Models
{
    public class UserInfo
    {
        public int id { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public int Rol { get; set; }
    }
}
