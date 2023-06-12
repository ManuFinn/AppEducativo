using AppEdu.Models;
using AppEdu.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEdu.ViewModels.DocenteMateriaVM
{
    public partial class BaseDocenteMateriaViewModel : BaseViewModel
    {
        [ObservableProperty]
        private DocenteMateria _docenteMateriaInfo;
    }
}
