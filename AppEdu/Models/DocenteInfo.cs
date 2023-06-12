using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEdu.Models
{
    public class DocenteInfo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public int Edad { get; set; }
        public int TipoDocente { get; set; }
        public int IdUsuario { get; set; }
        public string Usuario1 { get; set; }
        public string Contraseña { get; set; }

        public string NombreCompleto => $"{Nombre} {ApellidoPaterno} {ApellidoMaterno}";
    }
}
