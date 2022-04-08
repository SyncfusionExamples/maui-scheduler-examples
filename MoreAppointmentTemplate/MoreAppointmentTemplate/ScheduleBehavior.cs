using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Syncfusion.Maui.Scheduler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Scheduler = Syncfusion.Maui.Scheduler.SfScheduler;

namespace MoreAppointmentTemplate
{
    /// <summary>
    /// The scheduler view customization behavior.
    /// </summary>
    internal class ScheduleBehavior : Behavior<Syncfusion.Maui.Scheduler.SfScheduler>
    {
        /// <summary>
        /// Holds the appointment source collection.
        /// </summary>
        private ObservableCollection<Meeting>? appointments;

        /// <summary>
        /// Holds the scheduler object
        /// </summary>
        private Scheduler? scheduler;

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

            Meeting meeting1 = new();
            meeting1.Background = Colors.Red;
            meeting1.From = DateTime.Now.AddDays(1).AddHours(10);
            meeting1.To = DateTime.Now.AddDays(1).AddHours(12);
            meeting1.EventName = "AllDayAppointment";
            meeting1.Notes = "All day";
            meeting1.IsAllDay = true;
            appointments.Add(meeting1);

            Meeting meeting2 = new();
            meeting2.Background = Colors.Red;
            meeting2.From = DateTime.Now.AddDays(1).AddHours(10);
            meeting2.To = DateTime.Now.AddDays(1).AddHours(12);
            meeting2.EventName = "AllDayAppointment";
            meeting2.Notes = "All day";
            meeting2.IsAllDay = true;
            appointments.Add(meeting2);

            Meeting meeting3 = new();
            meeting3.Background = Colors.Red;
            meeting3.From = DateTime.Now.AddDays(1).AddHours(10);
            meeting3.To = DateTime.Now.AddDays(1).AddHours(12);
            meeting3.EventName = "AllDayAppointment";
            meeting3.Notes = "All day";
            meeting3.IsAllDay = true;
            appointments.Add(meeting3);

            Meeting meeting4 = new();
            meeting4.Background = Colors.Red;
            meeting4.From = DateTime.Now.AddDays(1).AddHours(10);
            meeting4.To = DateTime.Now.AddDays(1).AddHours(12);
            meeting4.EventName = "AllDayAppointment";
            meeting4.Notes = "All day";
            meeting4.IsAllDay = true;
            appointments.Add(meeting4);

            Meeting meeting5 = new();
            meeting5.Background = Colors.Red;
            meeting5.From = DateTime.Now.AddDays(1).AddHours(10);
            meeting5.To = DateTime.Now.AddDays(1).AddHours(12);
            meeting5.EventName = "AllDayAppointment";
            meeting5.Notes = "All day";
            meeting5.IsAllDay = true;
            appointments.Add(meeting5);


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

        protected override void OnDetachingFrom(Syncfusion.Maui.Scheduler.SfScheduler bindable)
        {
            base.OnDetachingFrom(bindable);
            this.scheduler = null;
            bindable.ViewChanged -= this.OnSchedulerViewChanged;
        }
    }
}