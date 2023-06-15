using AppEdu.ViewModels.CalendarioVM;

namespace AppEdu.Pages;

public partial class CalendarioPage : ContentPage
{
    CalendarioPageVM vm;

	public CalendarioPage()
	{
		InitializeComponent();
        this.BindingContext = vm = new CalendarioPageVM(Navigation);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        vm.OnAppearing();
    }

    private async void btnAddCalendario_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new AddUpdateCalendarioPage());
    }
}