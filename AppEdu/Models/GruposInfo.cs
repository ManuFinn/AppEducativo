using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEdu.Models
{
    public class GruposInfo
    {
        public int Id { get; set; }
        public int grado { get; set; }
        public string seccion { get; set; }

        public string Grupo => $"{grado}.{seccion}";
    }
}
