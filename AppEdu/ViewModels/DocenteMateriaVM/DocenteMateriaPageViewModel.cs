using AppEdu.Models;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEdu.ViewModels.DocenteMateriaVM
{
    public partial class DocenteMateriaPageViewModel : BaseDocenteMateriaViewModel
    {
        public ObservableCollection<DocenteMateria> docenteMateriaLista { get; }

        public DocenteMateriaPageViewModel()
        {
            docenteMateriaLista = new ObservableCollection<DocenteMateria>();
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
                docenteMateriaLista.Clear();
                var docMatelist = await App.DocenteMateriaService.GetAllDocenteMateriasAsync();
                foreach (var doceMate in docMatelist)
                {
                    docenteMateriaLista.Add(doceMate);
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
