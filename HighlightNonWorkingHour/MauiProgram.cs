using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Hosting;
using Syncfusion.Maui.Core.Hosting;

namespace HighlightNonWorkingHour
{
	public static class MauiProgram
	{
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder.ConfigureSyncfusionCore();
            builder
            .UseMauiApp<App>().ConfigureMauiHandlers(handlers =>
            {


            })
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("Segoe-mdl2.ttf", "SegoeMDL2");
            });

            return builder.Build();
        }
    }
}