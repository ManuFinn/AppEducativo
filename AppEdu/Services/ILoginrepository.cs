using AppEdu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEdu.Services
{
    public interface ILoginrepository
    {
        Task<object> Login(string userName, string password);
    }
}
