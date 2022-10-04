using Syncfusion.Maui.Scheduler;
using System.Collections.ObjectModel;

namespace SchedulerReminders
{
    public class ReminderBehavior : Behavior<SfScheduler>
    {
        protected override void OnAttachedTo(SfScheduler scheduler)
        {
            base.OnAttachedTo(scheduler);
            scheduler.ReminderAlertOpening += ReminderBehavior_ReminderAlertOpening;
        }

        private async void ReminderBehavior_ReminderAlertOpening(object sender, ReminderAlertOpeningEventArgs e)
        {
            ObservableCollection<SchedulerAppointment> appointments = (sender as SfScheduler).AppointmentsSource as ObservableCollection<SchedulerAppointment>;
            bool snooze = await App.Current.MainPage.DisplayAlert("Reminder", e.Reminders[0].Appointment.Subject + " - " + e.Reminders[0].Appointment.StartTime.ToString(" dddd, MMMM dd, yyyy, hh:mm tt"), "Snooze", "Dismiss");
           
            if (snooze)
            {
                TimeSpan snoozeTime = new TimeSpan(0, 2, 0);
                // To change alert time for future appointment reminder
                if (e.Reminders[0].Appointment.ActualStartTime > DateTime.Now && !e.Reminders[0].Appointment.IsAllDay)
                {
                    e.Reminders[0].TimeBeforeStart = e.Reminders[0].Appointment.StartTime - e.Reminders[0].AlertTime - snoozeTime;
                }
                // To change alert time for all day appointment reminder
                else if (e.Reminders[0].Appointment.IsAllDay)
                {
                    e.Reminders[0].TimeBeforeStart = e.Reminders[0].Appointment.StartTime.Date.AddSeconds(DateTime.Now.Second) - DateTime.Now - snoozeTime;
                }
                // To change alert time for overdue appointment reminder
                else
                {
                    e.Reminders[0].TimeBeforeStart = e.Reminders[0].Appointment.StartTime.AddSeconds(DateTime.Now.Second) - DateTime.Now - snoozeTime;
                }

                if (!string.IsNullOrEmpty(e.Reminders[0].Appointment.RecurrenceRule))
                {
                    SchedulerAppointment patternAppointment = appointments.FirstOrDefault(x => x.Id == e.Reminders[0].Appointment.Id);
                    DateTime changedExceptionDate = e.Reminders[0].Appointment.StartTime;
                    DateTime endDate = e.Reminders[0].Appointment.EndTime;
                    patternAppointment.RecurrenceExceptionDates = new ObservableCollection<DateTime>()
                        {
                            changedExceptionDate,
                        };
                    // Clone parent details
                    SchedulerAppointment exceptionAppointment = new SchedulerAppointment()
                    {
                        Id = 2,
                        Subject = patternAppointment.Subject,
                        StartTime = new DateTime(changedExceptionDate.Year, changedExceptionDate.Month, changedExceptionDate.Day, changedExceptionDate.Hour, 0, 0),
                        EndTime = new DateTime(endDate.Year, endDate.Month, endDate.Day, endDate.Hour, 0, 0),
                        Background = patternAppointment.Background,
                        RecurrenceId = 1,
                        Reminders = new ObservableCollection<SchedulerReminder> { new SchedulerReminder { TimeBeforeStart = e.Reminders[0].TimeBeforeStart } },
                    };
                    // For Recurrence appointment, if current occurrence need to snooze then need to add changed occurrence for reminder occurrence snoozed.
                    if (!appointments.Contains(exceptionAppointment))
                    {
                        appointments.Add(exceptionAppointment);
                    }
                }
            }
            else
            {
                // For Recurrence appointment, if current occurrence need to dismiss then need to add changed occurrence for reminder occurrence dismissed
                if (!string.IsNullOrEmpty(e.Reminders[0].Appointment.RecurrenceRule))
                {
                    SchedulerAppointment patternAppointment = appointments.FirstOrDefault(x => x.Id == e.Reminders[0].Appointment.Id);
                    DateTime changedExceptionDate = e.Reminders[0].Appointment.StartTime;
                    DateTime endDate = e.Reminders[0].Appointment.EndTime;
                    patternAppointment.RecurrenceExceptionDates = new ObservableCollection<DateTime>()
                        {
                            changedExceptionDate,
                        };
                    // Clone parent details
                    SchedulerAppointment exceptionAppointment = new SchedulerAppointment()
                    {
                        Id = 3,
                        Subject = patternAppointment.Subject,
                        StartTime = new DateTime(changedExceptionDate.Year, changedExceptionDate.Month, changedExceptionDate.Day, changedExceptionDate.Hour, 0, 0),
                        EndTime = new DateTime(endDate.Year, endDate.Month, endDate.Day, endDate.Hour, 0, 0),
                        Background = patternAppointment.Background,
                        RecurrenceId = 1,
                        Reminders = patternAppointment.Reminders,
                    };
                    if (!appointments.Contains(exceptionAppointment))
                    {
                        exceptionAppointment.Reminders[0].IsDismissed = true;
                        appointments.Add(exceptionAppointment);

                    }
                }
                // To dismiss normal reminder
                else
                {
                    for (int i = e.Reminders.Count - 1; i >= 0; i--)
                    {
                        e.Reminders[i].IsDismissed = true;
                    }
                }
            }
        }

    }
}
