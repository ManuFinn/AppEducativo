

namespace AppEdu.Pages;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}

    private async void btnDocentes_ClickedAsync(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new DocentePage());
    }

    private async void btnGrupos_ClickedAsync(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Docente_GrupoPage());
    }

    private async void btnAsignaturasAsync_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new DocenteMateriaPage());
    }
}