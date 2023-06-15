using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEdu.Models
{
    public class AlumnosInfo
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string grado { get; set; }
        public string seccion { get; set; }


        public string Grupo => $"{grado}.{seccion}";
        public string AlumnoWGrupo => $"{nombre} ({grado}.{seccion})";
    }
}
