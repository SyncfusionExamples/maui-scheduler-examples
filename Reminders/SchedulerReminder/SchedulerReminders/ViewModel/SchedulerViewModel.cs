using Syncfusion.Maui.Scheduler;
using System.Collections.ObjectModel;


namespace SchedulerReminders
{
    public class SchedulerViewModel
    {
        public ObservableCollection<SchedulerAppointment> Events { get; set; } = new ObservableCollection<SchedulerAppointment>();
        public SchedulerViewModel()
        {
            this.Events = new ObservableCollection<SchedulerAppointment>();
            this.CreateSchedulerAppointments();
        }

        private void CreateSchedulerAppointments()
        {
            // Normal Appointment
            SchedulerAppointment normalAppointment = new SchedulerAppointment()
            {
                StartTime = DateTime.Now.AddMinutes(5),
                EndTime = DateTime.Now.AddHours(1),
                Subject = "Normal Appointment",
                Background = Brush.SkyBlue,
                Reminders = new ObservableCollection<SchedulerReminder>
                {
                    new SchedulerReminder {TimeBeforeStart = new TimeSpan (0,4,0)},
                }

            };
            Events.Add(normalAppointment);

            // All Day Appointment
            SchedulerAppointment allDayAppointment = new SchedulerAppointment()
            {
                StartTime = DateTime.Now.AddDays(1).AddMinutes(1),
                EndTime = DateTime.Now.AddDays(1).AddHours(1),
                Subject = "All Day Appointment",
                Background = Brush.SkyBlue,
                IsAllDay = true,
                Reminders = new ObservableCollection<SchedulerReminder>
                {
                    new SchedulerReminder {TimeBeforeStart = new TimeSpan (0,0,50)},
                }

            };
            Events.Add(allDayAppointment);

            // Recurrence Appointment
            SchedulerAppointment recurrenceAppointment = new SchedulerAppointment()
            {
                Id = 1,
                StartTime = DateTime.Now.AddDays(2).AddMinutes(1),
                EndTime = DateTime.Now.AddDays(2).AddHours(1),
                Subject = "Recurrence Appointment",
                Background = Brush.LightGray,
                RecurrenceRule = "FREQ=DAILY;COUNT=3",
                Reminders = new ObservableCollection<SchedulerReminder>
                {
                    new SchedulerReminder {TimeBeforeStart = new TimeSpan (0,0,40)},
                }

            };
            Events.Add(recurrenceAppointment);
        }
    }
}
