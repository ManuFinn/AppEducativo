using AppEdu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEdu.Services.MateriaService
{
    public interface IMateriaRepository
    {
        Task<IEnumerable<MateriasInfo>> GetAllMateriasAsync();
    }
}
