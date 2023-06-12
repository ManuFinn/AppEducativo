using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEdu.Models
{
    public class MateriasInfo
    {
        public int id {  get; set; }
        public string nombre { get; set; }
        public int tipoAsignatura { get; set; }
        public int[] calificacion { get; set; }
        public string[] docenteAsignatura { get; set; }
    }
}
