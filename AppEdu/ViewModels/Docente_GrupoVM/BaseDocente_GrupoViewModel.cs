using AppEdu.Models;
using AppEdu.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEdu.ViewModels.Docente_GrupoVM
{
    public partial class BaseDocente_GrupoViewModel : BaseViewModel
    {
        [ObservableProperty]
        private Docente_Grupo _docenteGrupoInfo;

    }
}
