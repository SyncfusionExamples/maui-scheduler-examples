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
	}
    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new MainPage());
    }
}
