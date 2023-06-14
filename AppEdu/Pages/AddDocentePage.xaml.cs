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

    private async void btnCancelar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

}