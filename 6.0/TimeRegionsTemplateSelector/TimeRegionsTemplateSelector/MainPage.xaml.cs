using Syncfusion.Maui.Scheduler;
using System.Collections.ObjectModel;

namespace TimeRegionsTemplateSelector;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
		this.Scheduler.TimelineView.TimeRegions = this.GetTimeRegion();
        this.Scheduler.DaysView.TimeRegions = this.GetTimeRegion();
    }

    private ObservableCollection<SchedulerTimeRegion> GetTimeRegion()
    {
        var timeRegions = new ObservableCollection<SchedulerTimeRegion>();
        var recurrenceExceptionDates = DateTime.Now.Date.AddDays(3);
        var timeRegion = new SchedulerTimeRegion()
        {
            StartTime = DateTime.Today.Date.AddHours(13),
            EndTime = DateTime.Today.Date.AddHours(14),
            Text = "Lunch",
            EnablePointerInteraction = false,
            RecurrenceRule = "FREQ=DAILY;INTERVAL=1",
        };
        var BreakTimeRegion = new SchedulerTimeRegion()
        {
            StartTime = DateTime.Today.Date.AddHours(11),
            EndTime = DateTime.Today.Date.AddHours(11).AddMinutes(30),
            Text = "Break",
            EnablePointerInteraction = true,
            RecurrenceRule = "FREQ=DAILY;INTERVAL=1",
        };

        timeRegions.Add(timeRegion);
        timeRegions.Add(BreakTimeRegion);
        return timeRegions;
    }
}

