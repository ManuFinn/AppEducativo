using AppEdu.Models;
using AppEdu.Pages;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AppEdu.ViewModels.DirectorVM
{
    public partial class DirectorPageViewModel : BaseDirectorViewModel
    {
        public DirectorInfo director { get; }

        public DirectorPageViewModel(INavigation navi) {
            director = new DirectorInfo();
            Navigation = navi;
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        [RelayCommand]
        private async Task LoadDirector()
        {
            IsBusy = true;
            try
            {
                var direActual = await App.DirectorService.GetDirectorAsync();
                if (direActual != null)
                {
                    director.usuario = direActual.usuario;
                    director.nombre = direActual.nombre;
                    director.contraseña = direActual.contraseña;
                    director.telefono = direActual.telefono;
                    director.direccion = direActual.direccion;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { IsBusy = false; }
        }

        [RelayCommand]
        private async void DocenteEditar(DirectorInfo direIn)
        {
            if (direIn == null)
                return;
            //await Navigation.PushModalAsync(new EditDirectorPage(direIn));
        }
    }
}
