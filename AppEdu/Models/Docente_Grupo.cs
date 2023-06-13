using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEdu.Models
{
    public class Docente_Grupo
    {
        public int Id { get; set; }
        public int idDocente { get; set; }
        public string nombreProfe { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public int idGrupo { get; set; }
        public int grado { get; set; }
        public string seccion { get; set; }
        public int idPeriodo { get; set; }
        public int periodo { get; set; }

        public string NombreCompleto => $"{nombreProfe} {primerApellido} {segundoApellido}";

        public string Grupo => $"{grado}.{seccion}";

        public string NombreDocenteWGrupo => $"{nombreProfe} {primerApellido} {segundoApellido} ({grado}.{seccion})";
    }
}
