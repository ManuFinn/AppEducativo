

namespace AppEdu.Pages;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}

    private async void btnDocentes_ClickedAsync(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DocentePage());
    }

    private async void btnGrupos_ClickedAsync(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Docente_GrupoPage());
    }

    private async void btnAsignaturasAsync_ClickedAsync(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DocenteMateriaPage());
    }

    private async void btnDirector_ClickedAsync(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EditDirectorPage());
    }
}