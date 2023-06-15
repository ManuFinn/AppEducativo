using AppEdu.Models;
using AppEdu.Pages;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEdu.ViewModels.CalendarioVM
{
    public partial class CalendarioPageVM : BaseCalendarioVM
    {
        public ObservableCollection<CalendarioInfo> calendarioLista { get; }

        public CalendarioPageVM(INavigation navi)
        {
            calendarioLista = new ObservableCollection<CalendarioInfo>();
            Navigation = navi;
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        [RelayCommand]
        private async Task LoadCalendario()
        {
            IsBusy = true;
            try
            {
                calendarioLista.Clear();
                var calist = await App.CalendarioService.GetAllCalendariosAsync();
                foreach (var cale in calist)
                {
                    calendarioLista.Add(cale);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { IsBusy = false; }
        }

        [RelayCommand]
        private async void caleEditar(CalendarioInfo caIn)
        {
            if (caIn == null)
                return;
            await Navigation.PushModalAsync(new AddUpdateCalendarioPage(caIn));
        }

        [RelayCommand]
        private async void caleDelete(CalendarioInfo caIn)
        {
            if (caIn == null)
                return;
            await App.CalendarioService.DeleteCalendarioAsync(caIn.idCalendario);
            await LoadCalendario();
            OnAppearing();
        }
    }
}
