using AppEdu.Models;
using AppEdu.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEdu.ViewModels.CalendarioVM
{
    public partial class BaseCalendarioVM : BaseViewModel
    {
        [ObservableProperty]
        private CalendarioInfo _calendarioInfo;

        public INavigation Navigation { get; set; }
    }
}
