using AppEdu.Pages;
using AppEdu.ViewModels;
using Microsoft.Extensions.Logging;

namespace AppEdu;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<HomePage>();

        builder.Services.AddSingleton<DocenteViewModel>();
		builder.Services.AddSingleton<AddDocentePageViewModel>();

        builder.Services.AddSingleton<Docente_GrupoPage>();
        //builder.Services.AddSingleton<AddDocentePageViewModel>();

        return builder.Build();
	}
}
