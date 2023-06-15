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
		Combo();
	}

	private async void Combo()
	{
		vm = new AddUpdateNotasPageViewModel();
		await vm.obtenerAlu();
		pckAlumno.ItemsSource = vm.alumnoLista;
		pckAlumno.ItemDisplayBinding = new Binding("AlumnoWGrupo");

    }

	public AddUpdateNotaPage(NotasInfo nota)
    {
        InitializeComponent();
		this.BindingContext = new AddUpdateNotasPageViewModel();
        Combo();
        if (nota != null)
		{
            ((AddUpdateNotasPageViewModel)BindingContext).NotasInfo = nota;
		}
    }

    private async void btnCancelar_ClickedAsync(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    private async void btnAddUpdateNota_Clicked(object sender, EventArgs e)
    {
        vm = new AddUpdateNotasPageViewModel();
		AlumnosInfo Alumno = (AlumnosInfo)pckAlumno.SelectedItem;
		var idAlumno = 0;
		if(Alumno != null) { idAlumno = Alumno.id; }
		else { }

        Dictionary<string, string> datos = new Dictionary<string, string>();
        datos.Add("idAlumno", idAlumno.ToString());
        datos.Add("id", etyId.Text);
        datos.Add("titulo", etyTit.Text);
        datos.Add("descripcion", etyDesc.Text);

		vm.GuardarNota(datos);
    }
}