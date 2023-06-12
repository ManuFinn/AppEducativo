using AppEdu.Models;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEdu.ViewModels.Docente_GrupoVM
{
    public partial class Docente_GrupoPageViewModel : BaseDocente_GrupoViewModel
    {
        public ObservableCollection<Docente_Grupo> docenteGrupoLista { get; }

        public Docente_GrupoPageViewModel()
        {
            docenteGrupoLista = new ObservableCollection<Docente_Grupo>();
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        [RelayCommand]
        private async Task LoadDocenteGrupos()
        {
            IsBusy = true;
            try
            {
                docenteGrupoLista.Clear();
                var doclist = await App.Docente_GrupoService.GetAllDocenteGruposAsync();
                foreach (var docente in doclist)
                {
                    docenteGrupoLista.Add(docente);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { IsBusy = false; }
        }
    }
}
