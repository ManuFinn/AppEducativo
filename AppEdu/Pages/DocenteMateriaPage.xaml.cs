using AppEdu.ViewModels.DocenteMateriaVM;

namespace AppEdu.Pages;

public partial class DocenteMateriaPage : ContentPage
{
    DocenteMateriaPageViewModel vm;

	public DocenteMateriaPage()
	{
		InitializeComponent();
        vm = new DocenteMateriaPageViewModel();
        this.BindingContext = vm = new DocenteMateriaPageViewModel();
        cvDocenteMateria.ItemsSource = vm.docenteMateriaLista;

    }

    protected override void OnAppearing()
    {
        //base.OnAppearing();
        vm.OnAppearing();
    }

    private async void btnAddDocenteMateria_ClickedAsync(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new AddDocenteMateriaPage());
    }

}