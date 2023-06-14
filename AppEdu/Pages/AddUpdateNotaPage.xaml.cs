using AppEdu.Models;
using AppEdu.ViewModels.NotasVM;

namespace AppEdu.Pages;

public partial class AddUpdateNotaPage : ContentPage
{
	public NotasInfo NotasInfo { get; set; }

	public AddUpdateNotaPage()
	{
		InitializeComponent();
		this.BindingContext = new AddUpdateNotasPageViewModel();
	}

	public AddUpdateNotaPage(NotasInfo nota)
    {
        InitializeComponent();
		this.BindingContext = new AddUpdateNotasPageViewModel();
		if(nota != null)
		{
			((AddUpdateNotasPageViewModel)BindingContext).NotasInfo = nota;
		}
    }

    private async void btnAddUpdateNota_ClickedAsync(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    private async void btnCancelar_ClickedAsync(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}