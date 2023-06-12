using AppEdu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEdu.Services.Docente_GrupoService
{
    public interface IDocente_GrupoRepository
    {
        Task<IEnumerable<Docente_Grupo>> GetAllDocenteGruposAsync();

        Task<bool> AddUpdateDocenteAsync(Docente_Grupo docegruIn);
    }
}
