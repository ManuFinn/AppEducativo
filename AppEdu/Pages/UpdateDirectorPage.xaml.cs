using AppEdu.Models;
using AppEdu.ViewModels.DirectorVM;

namespace AppEdu.Pages;

public partial class UpdateDirectorPage : ContentPage
{
	public UpdateDirectorPage()
	{
		InitializeComponent();
		this.BindingContext = new UpdateDirectorViewModel();
	}

	public UpdateDirectorPage(DirectorInfo direIn)
	{
		InitializeComponent();
		this.BindingContext = new UpdateDirectorViewModel();
		if(direIn != null)
		{
			((UpdateDirectorViewModel)BindingContext).DirectorInfo = direIn;
		}
	}

    private async void btnCancelar_ClickedAsync(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

}