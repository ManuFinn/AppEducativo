using AppEdu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEdu.Services.DirectorService
{
    public interface IDirectorRepository
    {
        Task<IEnumerable<DirectorInfo>> GetDirectorAsync();

        Task<bool> UpdateDirectorAsync(DirectorInfo direIn);
    }
}
