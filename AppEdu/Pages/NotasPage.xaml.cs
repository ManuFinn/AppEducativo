using AppEdu.ViewModels.NotasVM;

namespace AppEdu.Pages;

public partial class NotasPage : ContentPage
{
    NotasPageViewModel vm;

	public NotasPage()
	{
		InitializeComponent();
        this.BindingContext = vm = new NotasPageViewModel(Navigation);
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        vm.OnAppearing();
    }

    private async void btnAddNota_ClickedAsync(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new AddUpdateNotaPage());
    }
}