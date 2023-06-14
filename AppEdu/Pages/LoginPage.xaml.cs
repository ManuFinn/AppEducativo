using AppEdu.Models;
using AppEdu.Services;

namespace AppEdu.Pages;

public partial class LoginPage : ContentPage
{
	readonly ILoginrepository _loginrepository = new LoginService();
	public LoginPage()
	{
		InitializeComponent();
	}

    private async void btnLogin_Clicked(object sender, EventArgs e)
    {
		string userName = etyUser.Text;
		string password = etyPass.Text;
		if (userName == null || password == null)
		{
            DisplayAlert("Advertencia", "Debe de escribir los datos", "Ok");
			return;
		}
		object usinfo = await _loginrepository.Login(userName, password);
		if(usinfo != null) {
            await Navigation.PushAsync(new HomePage());
        }
		else
		{
			DisplayAlert("Advertencia", "Datos incorrectos", "Ok");
			return;
		}
		
    }
}