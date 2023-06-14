using AppEdu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEdu.Services.NotasService
{
    public interface INotasRepository
    {
        Task<IEnumerable<NotasInfo>> GetAllNotasAsync();

        Task<bool> AddUpdateNotasAsync(NotasInfo notasIn);

        Task<bool> DeleteNotasAsync(int idNotas);
    }
}
