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
        await vm.obtenerDoc();
        pckNombreDocente.ItemsSource = vm.docenteLista;
        pckNombreDocente.ItemDisplayBinding = new Binding("NombreCompleto");
        await vm.obtenerGru();
        pckGrupo.ItemsSource = vm.grupoLista;
        pckGrupo.ItemDisplayBinding = new Binding("Grupo");
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
        DocenteInfo Docente = (DocenteInfo)pckNombreDocente.SelectedItem;
        var idDocente = Docente.Id;
        GruposInfo Grupo = (GruposInfo)pckGrupo.SelectedItem;
        var idgRUPO = Grupo.Id;
        MateriasInfo Materia = (MateriasInfo)pckAsignatura.SelectedItem;
        var idMateria = Materia.id;

        Dictionary<string, int> datos = new Dictionary<string, int>();
        datos.Add("idDocente", idDocente);
        datos.Add("idGrupo", idgRUPO);
        datos.Add("idAsignatura", idMateria);

        vm.GuardarDocenteMateria(datos);

        await Navigation.PopModalAsync();
    }

}