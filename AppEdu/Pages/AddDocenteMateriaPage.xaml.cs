using AppEdu.Models;
using AppEdu.ViewModels.DocenteMateriaVM;

namespace AppEdu.Pages;

public partial class AddDocenteMateriaPage : ContentPage
{
    AddDocenteMateriaViewModel vm;

	public AddDocenteMateriaPage()
	{
		InitializeComponent();
        ComboMix();
    }

    private async void ComboMix()
    {
        vm = new AddDocenteMateriaViewModel();
        await vm.obtenerDocGru();
        pckDocenteGrupo.ItemsSource = vm.docenteGruposLista;
        pckDocenteGrupo.ItemDisplayBinding = new Binding("NombreDocenteWGrupo");
        await vm.obtenerMat();
        pckAsignatura.ItemsSource = vm.materiasLista;
        pckAsignatura.ItemDisplayBinding = new Binding("nombre");
    }

    private async void btnCancelar_ClickedAsync(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    private async void btnAgregarDocenteMateria_ClickedAsync(object sender, EventArgs e)
    {
        vm = new AddDocenteMateriaViewModel();
        Docente_Grupo DocenteGrupo = (Docente_Grupo)pckDocenteGrupo.SelectedItem;
        var idDocente = DocenteGrupo.idDocente;
        var idGrupo = DocenteGrupo.idGrupo;
        MateriasInfo Materia = (MateriasInfo)pckAsignatura.SelectedItem;
        var idMateria = Materia.id;

        Dictionary<string, int> datos = new Dictionary<string, int>();
        datos.Add("idDocente", idDocente);
        datos.Add("idGrupo", idGrupo);
        datos.Add("idAsignatura", idMateria);

        vm.GuardarDocenteMateria(datos);

        await Navigation.PopModalAsync();
    }

}