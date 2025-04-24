using Syncfusion.Maui.Scheduler;
using System.Collections.ObjectModel;

namespace AllDayAppointmentTemplate
{
    internal class ScheduleBehavior : Behavior<SfScheduler>
    {
        /// <summary>
        /// Holds the appointment source collection.
        /// </summary>
        private ObservableCollection<Meeting>? appointments;

        /// <summary>
        /// Holds the scheduler object
        /// </summary>
        private SfScheduler? scheduler;

        protected override void OnAttachedTo(Syncfusion.Maui.Scheduler.SfScheduler bindable)
        {
            base.OnAttachedTo(bindable);
            this.scheduler = bindable;
            bindable.ViewChanged += this.OnSchedulerViewChanged;
        }

        private void OnSchedulerViewChanged(object? sender, SchedulerViewChangedEventArgs e)
        {
            if (this.scheduler == null || e.NewVisibleDates == null)
            {
                return;
            }

            var startDate = e.NewVisibleDates.FirstOrDefault();
            var random = new Random();
            appointments = new ObservableCollection<Meeting>();
            Meeting meeting = new();
            meeting.Background = Colors.Red;
            meeting.From = DateTime.Now.AddDays(1).AddHours(10);
            meeting.To = DateTime.Now.AddDays(1).AddHours(12);
            meeting.EventName = "AllDayAppointment";
            meeting.Notes = "All day";
            meeting.IsAllDay = true;
            appointments.Add(meeting);


            this.scheduler.AppointmentsSource = appointments;
        }

        protected override void OnDetachingFrom(Syncfusion.Maui.Scheduler.SfScheduler bindable)
        {
            base.OnDetachingFrom(bindable);
            this.scheduler = null;
            bindable.ViewChanged -= this.OnSchedulerViewChanged;
        }
    }
}
