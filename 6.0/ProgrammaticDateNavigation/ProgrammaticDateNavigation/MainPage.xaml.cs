namespace ProgrammaticDateNavigation;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}
	private void button_Clicked(object sender, EventArgs e)
	{
		this.scheduler.DisplayDate = DateTime.Now.AddDays(30);
	}
}

