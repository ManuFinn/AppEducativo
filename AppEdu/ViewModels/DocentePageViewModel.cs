using AppEdu.Models;
using AppEdu.Pages;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AppEdu.ViewModels
{
    public partial class DocentePageViewModel : BaseDocenteViewModel
    {
        public ObservableCollection<DocenteInfo> docenteLista { get; }

        public DocentePageViewModel(INavigation navi){
            docenteLista = new ObservableCollection<DocenteInfo>();
            Navigation = navi;
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        [RelayCommand]
        private async Task LoadDocente()
        {
            IsBusy = true;
            try
            {
                docenteLista.Clear();
                var doclist = await App.DocenteService.GetAllDocenteAsync();
                foreach(var docente in doclist)
                {
                    docenteLista.Add(docente);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { IsBusy = false; }
        }

        [RelayCommand]
        private async void DocenteEditar(DocenteInfo doIn)
        {
            if (doIn == null)
                return;
            await Navigation.PushModalAsync(new AddDocentePage(doIn));
        }
    }
}
