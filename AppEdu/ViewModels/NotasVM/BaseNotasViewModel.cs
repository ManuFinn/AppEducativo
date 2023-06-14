using AppEdu.Models;
using AppEdu.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEdu.ViewModels.NotasVM
{
    public partial class BaseNotasViewModel : BaseViewModel
    {
        [ObservableProperty]
        private NotasInfo _notasInfo;

        public INavigation Navigation { get; set; }
    }
}
