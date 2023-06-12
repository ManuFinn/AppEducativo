using AppEdu.Models;
using AppEdu.ViewModels;

namespace AppEdu.Pages;

public partial class AddDocentePage : ContentPage
{
	public DocenteInfo DocenteInfo { get; set; }
	public AddDocentePage()
	{
		InitializeComponent();
		this.BindingContext = new AddDocentePageViewModel();
	}

    public AddDocentePage(DocenteInfo doIn)
    {
        InitializeComponent();
        this.BindingContext = new AddDocentePageViewModel();
        if(doIn != null)
        {
            ((AddDocentePageViewModel)BindingContext).DocenteInfo = doIn;
        }
    }

    private async void btnAgregarDocente_Clicked(object sender, EventArgs e)
    {
		//AddDocentePageViewModel vm = new AddDocentePageViewModel();
		//vm.GuardarDocente();
		await Navigation.PopModalAsync();
    }

    private async void btnCancelar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}