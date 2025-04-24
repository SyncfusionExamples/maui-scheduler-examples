using Syncfusion.Maui.Scheduler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTemplate
{
    public class AppearanceCustomizationBehavior : Behavior<SfScheduler>
    {
        /// <summary>
        /// Holds the appointment source collection.
        /// </summary>
        private ObservableCollection<Meeting> appointments;

        /// <summary>
        /// Holds the scheduler object
        /// </summary>
        private SfScheduler scheduler;

        protected override void OnAttachedTo(SfScheduler bindable)
        {
            base.OnAttachedTo(bindable);
            this.scheduler = bindable;
            bindable.ViewChanged += this.OnSchedulerViewChanged;
        }

        private void OnSchedulerViewChanged(object sender, SchedulerViewChangedEventArgs e)
        {
            if (this.scheduler == null || e.NewVisibleDates == null)
            {
                return;
            }

            var startDate = e.NewVisibleDates.FirstOrDefault();
            var random = new Random();
            appointments = new ObservableCollection<Meeting>();
            if (this.scheduler.View == SchedulerView.Week || this.scheduler.View == SchedulerView.WorkWeek)
            {
                List<string> eventCollection = new()
        {
            "Environmental Discussion",
            "Health Checkup",
            "Cancer awareness",
            "Happiness",
            "Tourism"
        };

                List<string> notesCollection = new()
        {
            "A day that creates awareness to promote the healthy planet and reduce the air pollution crisis on nature earth.",
            "A day that raises awareness on different healthy issue. It marks the anniversary of the foundation of WHO.",
            "A day that raises awareness on cancer and its preventive measures. Early detection saves life.",
            "A general idea is to promote happiness and smile around the world.",
            "A day that raises awareness on the role of tourism and its effect on social and economic values."
        };

                List<Brush> colorCollection = new()
        {
            new SolidColorBrush(Color.FromArgb("#FF56AB56")),
            new SolidColorBrush(Color.FromArgb("#FF357CD2")),
            new SolidColorBrush(Color.FromArgb("#FF7FA90E")),
            new SolidColorBrush(Color.FromArgb("#ff8c00")),
            new SolidColorBrush(Color.FromArgb("#FF5BBEAF"))
        };

                List<string> imageCollection = new()
        {
            "environment_day.png",
            "health_day.png",
            "cancer_day.png",
            "happiness_day.png",
            "tourism_day.png"
        };

                if (e.NewVisibleDates.Any(d => d.Date == DateTime.Now.Date))
                {
                    startDate = startDate.AddDays(1);
                    for (int i = 0; i < 5; i++)
                    {
                        Meeting meeting = new();
                        meeting.Background = colorCollection[i];
                        meeting.From = startDate.AddDays(i).AddHours(10);
                        meeting.To = startDate.AddDays(i).AddHours(16);
                        meeting.EventName = eventCollection[i];
                        meeting.Notes = notesCollection[i];
                        meeting.Location = imageCollection[i];
                        appointments.Add(meeting);
                    }
                }
            }
            else if (this.scheduler.View == SchedulerView.TimelineDay || this.scheduler.View == SchedulerView.TimelineWeek || this.scheduler.View == SchedulerView.TimelineWorkWeek)
            {
                if (e.NewView == SchedulerView.TimelineDay)
                {
                    this.scheduler.TimelineView.TimeIntervalWidth = 150;
                }
                else
                {
                    this.scheduler.TimelineView.TimeIntervalWidth = 50;
                }

                if (e.OldView == SchedulerView.TimelineDay || e.OldView == SchedulerView.TimelineWeek || e.OldView == SchedulerView.TimelineWorkWeek)
                {
                    return;
                }

                List<Brush> colorCollection = this.GetColorCollection();
                List<string> currentDayMeetings = new()
        {
            "General Meeting",
            "Scrum",
            "Project Plan",
            "Consulting",
            "Support",
            "Yoga Therapy",
            "Plan Execution",
            "Project Plan",
            "Consulting",
            "Performance Check"
        };

                for (int i = -90; i < 120; i++)
                {
                    DateTime date = DateTime.Now.Date.AddDays(i);
                    for (int j = 0; j < 2; j++)
                    {
                        Meeting meeting = new();
                        meeting.Background = colorCollection[random.Next(0, 9)];
                        meeting.From = date.AddHours(random.Next(7, 16));
                        meeting.To = meeting.From.AddHours(4);
                        meeting.EventName = currentDayMeetings[random.Next(0, 9)];
                        appointments.Add(meeting);
                    }
                }
            }
            else
            {
                if (e.OldView == e.NewView)
                {
                    return;
                }

                if (e.NewView == SchedulerView.TimelineMonth)
                {
                    this.scheduler.TimelineView.TimeIntervalWidth = 150;
                }

                List<Brush> colorCollection = this.GetColorCollection();
                List<string> currentDayMeetings = new()
        {
            "General Meeting",
            "Scrum",
            "Project Plan",
            "Consulting",
            "Support",
            "Yoga Therapy",
            "Plan Execution",
            "Project Plan",
            "Consulting",
            "Performance Check"
        };

                for (int month = -3; month < 3; month++)
                {
                    for (int i = 0; i < 20; i++)
                    {
                        DateTime date = DateTime.Now.Date.AddMonths(month).AddDays(random.Next(0, 30));
                        Meeting meeting = new();
                        meeting.Background = colorCollection[random.Next(0, 9)];
                        meeting.From = date.AddHours(random.Next(9, 13));
                        meeting.To = meeting.From.AddHours(4);
                        meeting.EventName = currentDayMeetings[random.Next(0, 9)];
                        appointments.Add(meeting);
                    }
                }
            }

            this.scheduler.AppointmentsSource = appointments;
        }

        /// <summary>
        /// Method to get the color collection.
        /// </summary>
        private List<Brush> GetColorCollection()
        {
            var colorCollection = new List<Brush>
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

            return colorCollection;
        }

        protected override void OnDetachingFrom(SfScheduler bindable)
        {
            base.OnDetachingFrom(bindable);
            this.scheduler = null;
            bindable.ViewChanged -= this.OnSchedulerViewChanged;
        }
    }
}
