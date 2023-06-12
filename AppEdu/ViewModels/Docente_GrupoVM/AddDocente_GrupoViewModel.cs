using AppEdu.Models;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace AppEdu.ViewModels.Docente_GrupoVM
{
    public partial class AddDocente_GrupoViewModel : BaseDocente_GrupoViewModel
    {
        public ObservableCollection<DocenteInfo> docenteLista { get; }

        public ObservableCollection<GruposInfo> grupoLista { get; }

        public AddDocente_GrupoViewModel()
        {
            docenteLista = new ObservableCollection<DocenteInfo>();
            grupoLista = new ObservableCollection<GruposInfo>();
            DocenteGrupoInfo = new Docente_Grupo();
        }

        public async Task<IEnumerable<DocenteInfo>> obtenerDoc()
        {
            var doclist = await App.DocenteService.GetAllDocenteAsync();
            foreach (var docente in doclist)
            {
                docenteLista.Add(docente);
            }
            return docenteLista;
        }

        public async Task<IEnumerable<GruposInfo>> obtenerGru()
        {
            var grulist = await App.GrupoService.GetAllGruposAsync();
            foreach (var grupo in grulist)
            {
                grupoLista.Add(grupo);
            }
            return grupoLista;
        }

        public async void GuardarDocenteGrupo(Dictionary<string, int> datos)
        {
            Docente_Grupo info = new Docente_Grupo();
            if (datos.ContainsKey("idDocente")){
                info.idDocente = datos["idDocente"];
            }
            if (datos.ContainsKey("idGrupo"))
            {
                info.idGrupo = datos["idGrupo"];
            }
            await App.Docente_GrupoService.AddUpdateDocenteAsync(info);
        }
    }
}
