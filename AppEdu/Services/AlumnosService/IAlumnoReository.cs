using AppEdu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEdu.Services.AlumnosService
{
    public interface IAlumnoReository
    {
        Task<IEnumerable<AlumnosInfo>> GetAllAlumnosAsync();
    }
}
