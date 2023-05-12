using Syncfusion.Maui.Scheduler;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace LoadOnDemand
{
    public class LoadOnDemandViewModel : INotifyPropertyChanged
    {
        private bool showBusyIndicator;
        private ObservableCollection<SchedulerAppointment>? events;

        public ICommand QueryAppointmentsCommand { get; set; }
        public SchedulerView SchedulerView { get; set; }
        public ObservableCollection<SchedulerAppointment>? Events
        {
            get { return events; }
            set
            {
                events = value;
                this.RaiseOnPropertyChanged(nameof(Events));
            }
        }

        public bool ShowBusyIndicator
        {
            get { return showBusyIndicator; }
            set
            {
                showBusyIndicator = value;
                this.RaiseOnPropertyChanged(nameof(ShowBusyIndicator));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public LoadOnDemandViewModel()
        {
            this.SchedulerView = SchedulerView.Week;
            this.QueryAppointmentsCommand = new Command<object>(LoadMoreAppointments, CanLoadMoreAppointments);
        }

        private void RaiseOnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool CanLoadMoreAppointments(object obj)
        {
            return true;
        }

        private async void LoadMoreAppointments(object obj)
        {
            //// ShowBusyIndicator is used to start and stop the loading indicator animation before and after appointments are loaded with specified delay.
            this.ShowBusyIndicator = true;
            await Task.Delay(1500);
            var eventCollection = this.GenerateSchedulerAppointments(((SchedulerQueryAppointmentsEventArgs)obj).VisibleDates);

            //// To load more appointments when the new month is loaded on view.
            if (this.SchedulerView != SchedulerView.Agenda)
            {
                this.Events = eventCollection;
            }

            //// Can be reset for a new visible date range to improve appointment loading performance.
            else
            {
                foreach (var meeting in eventCollection)
                {
                    this.Events?.Add(meeting);
                }
            }
            this.ShowBusyIndicator = false;
        }

        private ObservableCollection<SchedulerAppointment> GenerateSchedulerAppointments(ReadOnlyCollection<DateTime> visibleDates)
        {
            var brush = new ObservableCollection<Brush>
    {
        new SolidColorBrush(Color.FromArgb("#FF8B1FA9")),
        new SolidColorBrush(Color.FromArgb("#FFD20100")),
        new SolidColorBrush(Color.FromArgb("#FFFC571D")),
        new SolidColorBrush(Color.FromArgb("#FF36B37B")),
        new SolidColorBrush(Color.FromArgb("#FF3D4FB5")),
        new SolidColorBrush(Color.FromArgb("#FFE47C73")),
        new SolidColorBrush(Color.FromArgb("#FF636363")),
        new SolidColorBrush(Color.FromArgb("#FF85461E")),
        new SolidColorBrush(Color.FromArgb("#FF0F8644")),
        new SolidColorBrush(Color.FromArgb("#FF01A1EF"))
    };

            var subjects = new ObservableCollection<string>
    {
        "Business Meeting",
        "Conference",
        "Medical check up",
        "Performance Check",
        "Consulting",
        "Project Status Discussion",
        "Client Meeting",
        "General Meeting",
        "Yoga Therapy",
        "GoToMeeting",
        "Plan Execution",
        "Project Plan"
    };

            Random ran = new();
            int daysCount = visibleDates.Count;
            DateTime visibleStartDate = visibleDates.FirstOrDefault();
            var appointments = new ObservableCollection<SchedulerAppointment>();
            for (int i = 0; i < 10; i++)
            {
                var startTime = visibleStartDate.AddDays(ran.Next(0, daysCount + 1)).AddHours(ran.Next(9, 16));
                appointments.Add(new SchedulerAppointment()
                {
                    StartTime = startTime,
                    EndTime = startTime.AddHours(1),
                    Subject = subjects[ran.Next(0, subjects.Count)],
                    Background = brush[ran.Next(0, brush.Count)]
                });
            }

            return appointments;
        }
    }
}
