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
        public ObservableCollection<DirectorInfo> director { get; }

        public DirectorPageViewModel(INavigation navi) {
            director = new ObservableCollection<DirectorInfo>();
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
                director.Clear();
                var direActual = await App.DirectorService.GetDirectorAsync();
                foreach (var dire in direActual)
                {
                    director.Add(dire);
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
            await Navigation.PushModalAsync(new UpdateDirectorPage(direIn));
        }
    }
}
