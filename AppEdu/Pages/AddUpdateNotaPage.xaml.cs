using AppEdu.Models;
using AppEdu.ViewModels.NotasVM;

namespace AppEdu.Pages;

public partial class AddUpdateNotaPage : ContentPage
{
	public NotasInfo NotasInfo { get; set; }

	AddUpdateNotasPageViewModel vm;

    public AddUpdateNotaPage()
	{
		InitializeComponent();
		this.BindingContext = vm = new AddUpdateNotasPageViewModel();
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

    private async void btnCancelar_ClickedAsync(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

}