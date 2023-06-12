using AppEdu.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEdu.ViewModels.DocenteMateriaVM
{
    public partial class AddDocenteMateriaViewModel : BaseDocenteMateriaViewModel
    {
        public ObservableCollection<DocenteInfo> docenteLista { get; }

        public ObservableCollection<GruposInfo> grupoLista { get; }

        public ObservableCollection<MateriasInfo> materiasLista { get; }

        public AddDocenteMateriaViewModel()
        {
            docenteLista = new ObservableCollection<DocenteInfo>();
            grupoLista = new ObservableCollection<GruposInfo>();
            materiasLista = new ObservableCollection<MateriasInfo>();

            DocenteMateriaInfo = new DocenteMateria();
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

        public async Task<IEnumerable<MateriasInfo>> obtenerMat()
        {
            var matlist = await App.MateriaService.GetAllMateriasAsync();
            foreach (var materia in matlist)
            {
                materiasLista.Add(materia);
            }
            return materiasLista;
        }

        public async void GuardarDocenteMateria(Dictionary<string, int> datos)
        {
            DocenteMateria info = new DocenteMateria();
            if (datos.ContainsKey("idDocente"))
            {
                info.idDocente = datos["idDocente"];
            }
            if (datos.ContainsKey("idGrupo"))
            {
                info.idGrupo = datos["idGrupo"];
            }
            if (datos.ContainsKey("idAsignatura"))
            {
                info.idAsignatura = datos["idAsignatura"];
            }
            await App.DocenteMateriaService.AddUpdateDocenteMateriaAsync(info);
        }
    }
}
