using AppEdu.Models;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEdu.ViewModels.CalendarioVM
{
    public partial class AddUpdateCalendarioVM : BaseCalendarioVM
    {
        public AddUpdateCalendarioVM() {
            CalendarioInfo = new CalendarioInfo();
        }

        [RelayCommand]
        public async void GuardarCalendario()
        {
            var cale = CalendarioInfo;
            await App.CalendarioService.AddUpdateCalendarioAsync(cale);
        }
    }
}
