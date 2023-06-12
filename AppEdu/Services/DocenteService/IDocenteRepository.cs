using AppEdu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEdu.Services.DocenteService
{
    public interface IDocenteRepository
    {
        Task<IEnumerable<DocenteInfo>> GetAllDocenteAsync();

        Task<bool> AddUpdateDocenteAsync(DocenteInfo doceIn);

    }
}
