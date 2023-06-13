using AppEdu.ViewModels;
using CommunityToolkit.Mvvm.Input;

namespace AppEdu.Pages;

public partial class DocentePage : ContentPage
{
    DocentePageViewModel docentePageVM;
    public DocentePage()
	{
		InitializeComponent();
        this.BindingContext = docentePageVM = new DocentePageViewModel(Navigation);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        docentePageVM.OnAppearing();
    }

    private async void btnAddDocente_ClickedAsync(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new AddDocentePage());
    }

    private async void tbiBack_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}