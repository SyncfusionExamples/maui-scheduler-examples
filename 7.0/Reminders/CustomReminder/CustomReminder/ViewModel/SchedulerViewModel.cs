using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomReminder
{
    public class SchedulerViewModel
    {
        public ObservableCollection<Event> Events { get; set; } = new ObservableCollection<Event>();
        public SchedulerViewModel()
        {
            this.Events = new ObservableCollection<Event>();
            this.CreateSchedulerAppointments();
        }

        private void CreateSchedulerAppointments()
        {
            // Normal Appointment
            Event normalAppointment = new Event()
            {
                From = DateTime.Now.AddMinutes(5),
                To = DateTime.Now.AddHours(1),
                EventName = "Normal Appointment",
                Color = Brush.SkyBlue,
                Reminders = new ObservableCollection<Reminder>
                {
                    new Reminder {TimeBeforeStart = new TimeSpan (0,4,0)},
                }

            };
            Events.Add(normalAppointment);

            // All Day Appointment
            Event allDayAppointment = new Event()
            {
                From = DateTime.Now.AddDays(1).AddMinutes(1),
                To = DateTime.Now.AddDays(1).AddHours(1),
                EventName = "All Day Appointment",
                Color = Brush.SkyBlue,
                IsAllDay = true,
                Reminders = new ObservableCollection<Reminder>
                {
                    new Reminder {TimeBeforeStart = new TimeSpan (0,0,50)},
                }

            };
            Events.Add(allDayAppointment);

            // Recurrence Appointment
            Event recurrenceAppointment = new Event()
            {
                Id = 1,
                From = DateTime.Now.AddDays(2).AddMinutes(1),
                To = DateTime.Now.AddDays(2).AddHours(1),
                EventName = "Recurrence Appointment",
                Color = Brush.LightGray,
                RecurrenceRule = "FREQ=DAILY;COUNT=3",
                Reminders = new ObservableCollection<Reminder>
                {
                    new Reminder {TimeBeforeStart = new TimeSpan (0,0,40)},
                }

            };
            Events.Add(recurrenceAppointment);

        }
    }
}
