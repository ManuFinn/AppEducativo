using AppEdu.Models;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEdu.ViewModels
{
    public partial class AddDocentePageViewModel : BaseDocenteViewModel
    {
        public bool Worked;

        public AddDocentePageViewModel() {
            DocenteInfo = new DocenteInfo();
        }

        [RelayCommand]
        public async void GuardarDocente()
        {
            var docente = DocenteInfo;
            await App.DocenteService.AddUpdateDocenteAsync(docente);
        }
    }
}
