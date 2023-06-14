using AppEdu.Models;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEdu.ViewModels.NotasVM
{
    public partial class AddUpdateNotasPageViewModel : BaseNotasViewModel
    {
        public bool Worked;

        public AddUpdateNotasPageViewModel()
        {
            NotasInfo = new NotasInfo();
        }

        [RelayCommand]
        public async void GuardarNota()
        {
            var nota = NotasInfo;
            await App.NotasService.AddUpdateNotasAsync(nota);
        }
    }
}
