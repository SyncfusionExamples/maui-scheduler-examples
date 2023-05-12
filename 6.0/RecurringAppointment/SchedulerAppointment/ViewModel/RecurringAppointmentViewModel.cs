using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Syncfusion.Maui.Scheduler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RecurringSchedulerAppointment
{
    /// <summary>
    /// The recurring appointment view model.
    /// </summary>
    public class RecurringAppointmentViewModel
    {
        #region Fields

        /// <summary>
        /// color collection
        /// </summary>
        private List<Brush> colorCollection;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RecurringAppointmentViewModel" /> class.
        /// </summary>
        public RecurringAppointmentViewModel()
        {
            this.CreateColorCollection();
            this.GenerateRecurrsiveAppointments();
            this.DisplayDate = DateTime.Now.Date.AddHours(8).AddMinutes(50);
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets or sets recursive appointments.
        /// </summary>
        public ObservableCollection<SchedulerAppointment> RecursiveEvents { get; set; }

        /// <summary>
        /// Gets or sets the schedule display date.
        /// </summary>
        public DateTime DisplayDate { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Method to create the color collection.
        /// </summary>
        private void CreateColorCollection()
        {
            this.colorCollection = new List<Brush>();

            this.colorCollection.Add(new SolidColorBrush(Color.FromArgb("#FF8B1FA9")));
            this.colorCollection.Add(new SolidColorBrush(Color.FromArgb("#FFD20100")));
            this.colorCollection.Add(new SolidColorBrush(Color.FromArgb("#FFFC571D")));
            this.colorCollection.Add(new SolidColorBrush(Color.FromArgb("#FF36B37B")));
            this.colorCollection.Add(new SolidColorBrush(Color.FromArgb("#FF3D4FB5")));
            this.colorCollection.Add(new SolidColorBrush(Color.FromArgb("#FFE47C73")));
            this.colorCollection.Add(new SolidColorBrush(Color.FromArgb("#FF636363")));
            this.colorCollection.Add(new SolidColorBrush(Color.FromArgb("#FF85461E")));
            this.colorCollection.Add(new SolidColorBrush(Color.FromArgb("#FF0F8644")));
            this.colorCollection.Add(new SolidColorBrush(Color.FromArgb("#FF01A1EF")));
        }

        /// <summary>
        /// Generate the recursive appointments.
        /// </summary>
        private void GenerateRecurrsiveAppointments()
        {
            this.RecursiveEvents = new ObservableCollection<SchedulerAppointment>();
            Random ran = new Random();
            DateTime currentDate = DateTime.Now.AddMonths(-1);

            var dailyEvent = new SchedulerAppointment
            {
                Subject = "Daily recurring meeting",
                StartTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 9, 0, 0),
                EndTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 10, 0, 0),
                Background = this.colorCollection[ran.Next(10)],
                RecurrenceRule = "FREQ=DAILY;INTERVAL=1;COUNT=100"
            };

            this.RecursiveEvents.Add(dailyEvent);

            var weeklyEvent = new SchedulerAppointment
            {
                Subject = "Weekly recurring meeting",
                StartTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 11, 0, 0),
                EndTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 12, 0, 0),
                Background = this.colorCollection[ran.Next(1, 10)],
                RecurrenceRule = "FREQ=WEEKLY;BYDAY=MO,WE,FR;INTERVAL=1;COUNT=20"
            };

            this.RecursiveEvents.Add(weeklyEvent);

            var monthlyEvent = new SchedulerAppointment
            {
                Subject = "Monthly recurring Meeting",
                StartTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 12, 0, 0),
                EndTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 13, 0, 0),
                Background = this.colorCollection[ran.Next(1, 10)],
                RecurrenceRule = "FREQ=MONTHLY;BYDAY=TU;BYSETPOS=1;INTERVAL=1;COUNT=50"
            };

            this.RecursiveEvents.Add(monthlyEvent);

            var yearlyEvent = new SchedulerAppointment
            {
                Subject = "Yearly recurring Meeting",
                StartTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 2, 0, 0),
                EndTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 3, 0, 0),
                Background = this.colorCollection[ran.Next(1, 10)],
                RecurrenceRule = "FREQ=YEARLY;BYMONTHDAY=3;BYMONTH=5;INTERVAL=1;COUNT=50"
            };

            this.RecursiveEvents.Add(yearlyEvent);
        }

        #endregion
    }
}