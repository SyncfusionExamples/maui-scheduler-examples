﻿using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Syncfusion.Maui.Scheduler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Scheduler = Syncfusion.Maui.Scheduler.SfScheduler;

namespace AllDayAppointmentTemplate
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