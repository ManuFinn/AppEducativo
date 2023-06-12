using AppEdu.Pages;

namespace AppEdu;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		//this.BindingContext = new AppShellViewModel();
		Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
		Routing.RegisterRoute(nameof(AddDocentePage), typeof(HomePage));
    }
}
