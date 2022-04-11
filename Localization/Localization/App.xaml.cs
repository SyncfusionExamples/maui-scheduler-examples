using Syncfusion.Maui.Scheduler;
using System.Globalization;
using System.Resources;

namespace Localization;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
        CultureInfo.CurrentUICulture = new CultureInfo("fr-FR");

        SfSchedulerResources.ResourceManager = new ResourceManager("Localization.Resources.SfScheduler", Application.Current.GetType().Assembly);

        MainPage = new MainPage();
	}
}
