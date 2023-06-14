using AppEdu.Models;
using AppEdu.ViewModels.Docente_GrupoVM;
using Microsoft.Maui.Controls;
using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.Runtime.Intrinsics.X86;

namespace AppEdu.Pages;

public partial class AddDocente_GrupoPage : ContentPage
{
    AddDocente_GrupoViewModel vm;

    public Docente_Grupo Docente_Grupo { get; set; }

    public AddDocente_GrupoPage()
	{
		InitializeComponent();
        this.BindingContext = new AddDocente_GrupoViewModel();
        ComboMix();
    }

    public AddDocente_GrupoPage(Docente_Grupo doGru)
    {
        InitializeComponent();
        this.BindingContext = new AddDocente_GrupoViewModel();
        if (doGru != null)
        {
            ((AddDocente_GrupoPage)BindingContext).Docente_Grupo = doGru;
        }
    }

    private async void ComboMix()
    {
        vm = new AddDocente_GrupoViewModel();
        await vm.obtenerDoc();
        pckNombreDocente.ItemsSource = vm.docenteLista;
        pckNombreDocente.ItemDisplayBinding = new Binding("NombreCompleto");
        pckNombreDocente.SetBinding(Picker.SelectedItemProperty, "DocenteInfo.Id");
        await vm.obtenerGru();
        pckGrupo.ItemsSource = vm.grupoLista;
        pckGrupo.ItemDisplayBinding = new Binding("Grupo");
        pckGrupo.SetBinding(Picker.SelectedItemProperty, "GrupoInfo.Id");
    }

    private async void btnCancelar_ClickedAsync(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    private void btnAgregarDocenteGrupo_ClickedAsync(object sender, EventArgs e)
    {
        vm = new AddDocente_GrupoViewModel();

        DocenteInfo Docente = (DocenteInfo)pckNombreDocente.SelectedItem;
        var idDocente = 0;
        if (Docente != null) { idDocente = Docente.Id; }
        else {  }
        GruposInfo Grupo = (GruposInfo)pckGrupo.SelectedItem;
        var idgRUPO = 0;
        if (Grupo != null) { idgRUPO = Grupo.Id; }
        else { }

        Dictionary<string, int> datos = new Dictionary<string, int>();
        datos.Add("idDocente", idDocente);
        datos.Add("idGrupo", idgRUPO);

        vm.GuardarDocenteGrupo(datos);
    }
}