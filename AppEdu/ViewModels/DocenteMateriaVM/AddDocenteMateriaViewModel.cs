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
        public ObservableCollection<Docente_Grupo> docenteGruposLista { get; }

        public ObservableCollection<MateriasInfo> materiasLista { get; }

        public AddDocenteMateriaViewModel()
        {
            docenteGruposLista = new ObservableCollection<Docente_Grupo>();
            materiasLista = new ObservableCollection<MateriasInfo>();

            DocenteMateriaInfo = new DocenteMateria();
        }

        public async Task<IEnumerable<Docente_Grupo>> obtenerDocGru(){
            var dogruList = await App.Docente_GrupoService.GetAllDocenteGruposAsync();
            foreach (var dogru in dogruList)
            {
                docenteGruposLista.Add(dogru);
            }
            return docenteGruposLista;
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
