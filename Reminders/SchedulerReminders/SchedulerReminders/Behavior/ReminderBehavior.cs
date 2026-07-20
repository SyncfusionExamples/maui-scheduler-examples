using Syncfusion.Maui.Scheduler;
using System.Collections.ObjectModel;
using System.Linq;

namespace SchedulerReminders
{
    public class ReminderBehavior : Behavior<SfScheduler>
    {
        protected override void OnAttachedTo(SfScheduler scheduler)
        {
            base.OnAttachedTo(scheduler);
            scheduler.ReminderAlertOpening += ReminderBehavior_ReminderAlertOpening;
        }

        protected override void OnDetachingFrom(SfScheduler scheduler)
        {
            base.OnDetachingFrom(scheduler);
            scheduler.ReminderAlertOpening -= ReminderBehavior_ReminderAlertOpening;
        }

        private async void ReminderBehavior_ReminderAlertOpening(object? sender, ReminderAlertOpeningEventArgs e)
        {
            if (sender is not SfScheduler scheduler
                || scheduler.AppointmentsSource is not ObservableCollection<SchedulerAppointment> appointments
                || e.Reminders is null
                || e.Reminders.Count == 0)
            {
                return;
            }

            SchedulerReminder reminder = e.Reminders[0];
            SchedulerAppointment? appointment = reminder.Appointment;
            if (appointment is null)
            {
                return;
            }

            var currentPage = Application.Current?.Windows?.FirstOrDefault()?.Page;
            if (currentPage is null)
            {
                return;
            }

            bool snooze = await currentPage.DisplayAlert(
                "Reminder",
                appointment.Subject + " - " + appointment.StartTime.ToString(" dddd, MMMM dd, yyyy, hh:mm tt"),
                "Snooze",
                "Dismiss");

            if (snooze)
            {
                TimeSpan snoozeTime = TimeSpan.FromMinutes(2);
                // To change alert time for future appointment reminder
                if (appointment.ActualStartTime > DateTime.Now && !appointment.IsAllDay)
                {
                    reminder.TimeBeforeStart = appointment.StartTime - reminder.AlertTime - snoozeTime;
                }
                // To change alert time for all day appointment reminder
                else if (appointment.IsAllDay)
                {
                    reminder.TimeBeforeStart = appointment.StartTime.Date.AddSeconds(DateTime.Now.Second) - DateTime.Now - snoozeTime;
                }
                // To change alert time for overdue appointment reminder
                else
                {
                    reminder.TimeBeforeStart = appointment.StartTime.AddSeconds(DateTime.Now.Second) - DateTime.Now - snoozeTime;
                }

                if (!string.IsNullOrEmpty(appointment.RecurrenceRule))
                {
                    SchedulerAppointment? patternAppointment = appointments.FirstOrDefault(x => x.Id == appointment.Id);
                    if (patternAppointment is null)
                    {
                        return;
                    }

                    DateTime changedExceptionDate = appointment.StartTime;
                    DateTime endDate = appointment.EndTime;
                    patternAppointment.RecurrenceExceptionDates = new ObservableCollection<DateTime>
                    {
                        changedExceptionDate,
                    };
                    // Clone parent details
                    SchedulerAppointment exceptionAppointment = new SchedulerAppointment
                    {
                        Id = 2,
                        Subject = patternAppointment.Subject,
                        StartTime = new DateTime(changedExceptionDate.Year, changedExceptionDate.Month, changedExceptionDate.Day, changedExceptionDate.Hour, 0, 0),
                        EndTime = new DateTime(endDate.Year, endDate.Month, endDate.Day, endDate.Hour, 0, 0),
                        Background = patternAppointment.Background,
                        RecurrenceId = 1,
                        Reminders = new ObservableCollection<SchedulerReminder> { new SchedulerReminder { TimeBeforeStart = reminder.TimeBeforeStart } },
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
                if (!string.IsNullOrEmpty(appointment.RecurrenceRule))
                {
                    SchedulerAppointment? patternAppointment = appointments.FirstOrDefault(x => x.Id == appointment.Id);
                    if (patternAppointment is null)
                    {
                        return;
                    }

                    DateTime changedExceptionDate = appointment.StartTime;
                    DateTime endDate = appointment.EndTime;
                    patternAppointment.RecurrenceExceptionDates = new ObservableCollection<DateTime>
                    {
                        changedExceptionDate,
                    };
                    // Clone parent details
                    SchedulerAppointment exceptionAppointment = new SchedulerAppointment
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
