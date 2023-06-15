using AppEdu.Models;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEdu.ViewModels.NotasVM
{
    public partial class AddUpdateNotasPageViewModel : BaseNotasViewModel
    {
        public bool Worked;

        public ObservableCollection<AlumnosInfo> alumnoLista { get; }

        public AddUpdateNotasPageViewModel()
        {
            NotasInfo = new NotasInfo();
            alumnoLista = new ObservableCollection<AlumnosInfo>();
        }

        public async Task<IEnumerable<AlumnosInfo>> obtenerAlu(){
            var aluList = await App.AlumnoService.GetAllAlumnosAsync();
            foreach(var alumnos in aluList)
            {
                alumnoLista.Add(alumnos);
            }
            return alumnoLista;
        }

        
        public async void GuardarNota(Dictionary<string, string> datos)
        {
            NotasInfo info = new NotasInfo();
            if (datos.ContainsKey("id"))
            {
                info.id = int.Parse(datos["id"]);
            }
            if (datos.ContainsKey("titulo"))
            {
                info.titulo = datos["titulo"];
            }
            if (datos.ContainsKey("descripcion"))
            {
                info.descripcion = datos["descripcion"];
            }
            if (datos.ContainsKey("idAlumno"))
            {
                info.idAlumno = int.Parse(datos["idAlumno"]);
            }
            await App.NotasService.AddUpdateNotasAsync(info);
        }
    }
}
