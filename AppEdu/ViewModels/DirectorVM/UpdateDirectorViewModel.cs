using AppEdu.Models;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEdu.ViewModels.DirectorVM
{
    public partial class UpdateDirectorViewModel : BaseDirectorViewModel
    {
        public UpdateDirectorViewModel() {
            DirectorInfo = new DirectorInfo();
        }

        [RelayCommand]
        public async void GuardarDirector()
        {
            var dire = DirectorInfo;
            await App.DirectorService.UpdateDirectorAsync(dire);

        }
    }
}
