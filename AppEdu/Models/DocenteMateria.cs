using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace AppEdu.Models
{
    public class DocenteMateria
    {
        public int idDocente { get; set; }
        public string nombreProfe { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public int idAsignatura { get; set; }
        public string asignatura { get; set; }
        public int idGrupo { get; set; }

        public string NombreDocente => $"{nombreProfe} {primerApellido} {segundoApellido}";
    }
}
