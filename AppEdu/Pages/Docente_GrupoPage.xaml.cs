using AppEdu.ViewModels.Docente_GrupoVM;

namespace AppEdu.Pages;

public partial class Docente_GrupoPage : ContentPage
{
    Docente_GrupoPageViewModel docenteGrupoVM;

	public Docente_GrupoPage()
	{
		InitializeComponent();
        this.BindingContext = docenteGrupoVM = new Docente_GrupoPageViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        docenteGrupoVM.OnAppearing();
    }

    private async void btnAddDocenteGrupo_ClickedAsync(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddDocente_GrupoPage());
    }
}