using AppEdu.Models;
using AppEdu.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AppEdu.ViewModels
{
    public partial class BaseDocenteViewModel : BaseViewModel
    {
        [ObservableProperty]
        private DocenteInfo _docenteInfo;

        public INavigation Navigation { get; set; }
    }
}
