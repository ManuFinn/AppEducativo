using AppEdu.Models;
using AppEdu.ViewModels;
using AppEdu.ViewModels.CalendarioVM;

namespace AppEdu.Pages;

public partial class AddUpdateCalendarioPage : ContentPage
{
    public CalendarioInfo CalendarioInfo { get; set; }

	public AddUpdateCalendarioPage()
	{
		InitializeComponent();
        this.BindingContext = new AddUpdateCalendarioVM();
	}

    public AddUpdateCalendarioPage(CalendarioInfo caInfo)
    {
        InitializeComponent();
        this.BindingContext = new AddUpdateCalendarioVM();
        if(caInfo != null)
        {
            ((AddUpdateCalendarioVM)BindingContext).CalendarioInfo = caInfo;
        }
    }

    private async void btnCancelar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}