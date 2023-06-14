using AppEdu.Models;
using AppEdu.Pages;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEdu.ViewModels.NotasVM
{
    public partial class NotasPageViewModel : BaseNotasViewModel
    {
        public ObservableCollection<NotasInfo> notasLista { get; }

        public NotasPageViewModel(INavigation navi)
        {
            notasLista = new ObservableCollection<NotasInfo>();
            Navigation = navi;
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        [RelayCommand]
        private async Task LoadNotas()
        {
            IsBusy = true;
            try
            {
                notasLista.Clear();
                var nolist = await App.NotasService.GetAllNotasAsync();
                foreach (var nota in nolist)
                {
                    notasLista.Add(nota);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { IsBusy = false; }
        }

        [RelayCommand]
        private async void notasEditar(NotasInfo noIn)
        {
            if (noIn == null)
                return;
            await Navigation.PushModalAsync(new AddUpdateNotaPage(noIn));
        }

        [RelayCommand]
        private async void notasDelete(NotasInfo noIn)
        {
            if (noIn == null)
                return;
            await App.NotasService.DeleteNotasAsync(noIn.id);
            await LoadNotas();
            OnAppearing();
        }
    }
}
