using AppEdu.Models;
using AppEdu.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEdu.ViewModels.DirectorVM
{
    public partial class BaseDirectorViewModel : BaseViewModel
    {
        [ObservableProperty]
        private DirectorInfo _directorInfo;

        public INavigation Navigation { get; set; }
    }
}
