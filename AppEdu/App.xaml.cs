using AppEdu.Models;
using AppEdu.Pages;
using AppEdu.Services.Docente_GrupoService;
using AppEdu.Services.DocenteMateriaService;
using AppEdu.Services.DocenteService;
using AppEdu.Services.GrupoService;
using AppEdu.Services.MateriaService;

namespace AppEdu;

public partial class App : Application
{
	public static DocenteInfo DocenteInfo;
	public static DocenteService _docenteService;

	public static Docente_Grupo DocenteGrupo;
	public static Docente_GrupoService _docenteGrupoService;

    public static GruposInfo GrupoInfo;
    public static GrupoService _grupoService;

    public static MateriasInfo MateriasInfo;
    public static MateriaService _materiaService;

    public static DocenteMateria DocenteMateria;
    public static DocenteMateriaService _docenteMateriaService;

    public static DocenteService DocenteService
	{
		get
		{
			if(_docenteService == null)
			{
				_docenteService = new DocenteService();
			}
			return _docenteService;
		}
	}

    public static Docente_GrupoService Docente_GrupoService
    {
        get
        {
            if (_docenteGrupoService == null)
            {
                _docenteGrupoService = new Docente_GrupoService();
            }
            return _docenteGrupoService;
        }
    }

    public static GrupoService GrupoService
    {
        get
        {
            if (_grupoService == null)
            {
                _grupoService = new GrupoService();
            }
            return _grupoService;
        }
    }

    public static MateriaService MateriaService
    {
        get
        {
            if (_materiaService == null)
            {
                _materiaService = new MateriaService();
            }
            return _materiaService;
        }
    }

    public static DocenteMateriaService DocenteMateriaService
    {
        get
        {
            if (_docenteMateriaService == null)
            {
                _docenteMateriaService = new DocenteMateriaService();
            }
            return _docenteMateriaService;
        }
    }

    public App()
	{
		InitializeComponent();

		MainPage = new LoginPage();
	}
}
