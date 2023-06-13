using AppEdu.ViewModels.DirectorVM;

namespace AppEdu.Pages;

public partial class DirectorPage : ContentPage
{
	DirectorPageViewModel vm;
	public DirectorPage()
	{
		InitializeComponent();
		this.BindingContext = vm = new DirectorPageViewModel(Navigation);
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        vm.OnAppearing();
    }
}