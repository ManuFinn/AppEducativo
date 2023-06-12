using AppEdu.ViewModels.DocenteMateriaVM;

namespace AppEdu.Pages;

public partial class DocenteMateriaPage : ContentPage
{
    DocenteMateriaPageViewModel vm;

	public DocenteMateriaPage()
	{
		InitializeComponent();
        this.BindingContext = vm = new DocenteMateriaPageViewModel();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        vm.OnAppearing();
    }

    private async void btnAddDocenteMateria_ClickedAsync(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new AddDocenteMateriaPage());
    }

    private async void tbiBack_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}