using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEdu.Models
{
    public class DirectorInfo
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public int idusuario { get; set; }
        public int idusuarioNavigation { get; set; }
    }
}
