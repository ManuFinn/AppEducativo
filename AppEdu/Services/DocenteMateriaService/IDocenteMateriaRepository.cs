using AppEdu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEdu.Services.DocenteMateriaService
{
    public interface IDocenteMateriaRepository
    {
        Task<IEnumerable<DocenteMateria>> GetAllDocenteMateriasAsync();

        Task<bool> AddUpdateDocenteMateriaAsync(DocenteMateria doceMate);
    }
}
