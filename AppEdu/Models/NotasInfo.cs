using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEdu.Models
{
    public class NotasInfo
    {
        public int id {  get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public int idAlumno { get; set; }
        public string nombreAlumno { get; set; }
        public string grado { get; set; }
        public string seccion { get; set; }

        public string Grupo => $"{grado}.{seccion}";

        public string AlumnoWGrupo => $"{nombreAlumno} ({grado}.{seccion})";
    }
}
