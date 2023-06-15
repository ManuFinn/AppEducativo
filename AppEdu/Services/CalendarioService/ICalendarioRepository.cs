using AppEdu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEdu.Services.CalendarioService
{
    public interface ICalendarioRepository
    {
        Task<IEnumerable<CalendarioInfo>> GetAllCalendariosAsync();

        Task<bool> AddUpdateCalendarioAsync(CalendarioInfo caleInfo);

        Task<bool> DeleteCalendarioAsync(int idCale);
    }
}
