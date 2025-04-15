using Syncfusion.Maui.Scheduler;
using System.Collections.ObjectModel;

namespace RecursiveExceptionAppointment
{
    /// <summary>
    /// The recursive exception appointment view model.
    /// </summary>
    public class SchedulerViewModel
    {
        #region Fields

        /// <summary>
        /// The color collection.
        /// </summary>
        private List<Brush> colorCollection = new List<Brush>();

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SchedulerViewModel" /> class.
        /// </summary>
        public SchedulerViewModel()
        {
            this.CreateColorCollection();
            this.GenerateRecurrsiveExceptionAppointments();
            this.DisplayDate = DateTime.Now.Date.AddHours(8).AddMinutes(50);
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets or sets recursive appointments.
        /// </summary>
        public ObservableCollection<SchedulerAppointment> RecursiveExceptionEvents { get; set; } = new ObservableCollection<SchedulerAppointment>();

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
        /// Generate the recursive exception appointments.
        /// </summary>
        private void GenerateRecurrsiveExceptionAppointments()
        {
            this.RecursiveExceptionEvents = new ObservableCollection<SchedulerAppointment>();

            Random ran = new Random();
            DateTime currentDate = DateTime.Now.AddMonths(-1);

            var dailyEvent = new SchedulerAppointment
            {
                Subject = "Daily scrum meeting",
                StartTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 10, 0, 0),
                EndTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 11, 0, 0),
                Background = this.colorCollection[ran.Next(10)],
                RecurrenceRule = "FREQ=DAILY;INTERVAL=1;COUNT=50",
                Id = 1
            };

            this.RecursiveExceptionEvents.Add(dailyEvent);

            //// Add ExceptionDates to avoid occurrence on specific dates.
            DateTime changedExceptionDate1 = DateTime.Now.AddDays(-1).Date;
            DateTime changedExceptionDate2 = DateTime.Now.Date.AddDays(4).Date;
            DateTime deletedExceptionDate1 = DateTime.Now.Date.AddDays(2);
            DateTime deletedExceptionDate2 = DateTime.Now.Date.AddDays(6);
            DateTime deletedExceptionDate3 = DateTime.Now.Date.AddDays(8);

            dailyEvent.RecurrenceExceptionDates = new ObservableCollection<DateTime>()
            {
                changedExceptionDate1,
                changedExceptionDate2,
                deletedExceptionDate1,
                deletedExceptionDate2,
            };

            //// Change start time or end time of an occurrence.
            var changedEvent = new SchedulerAppointment
            {
                Subject = "Scrum meeting - Changed Occurrence",
                StartTime = new DateTime(changedExceptionDate1.Year, changedExceptionDate1.Month, changedExceptionDate1.Day, 12, 0, 0),
                EndTime = new DateTime(changedExceptionDate1.Year, changedExceptionDate1.Month, changedExceptionDate1.Day, 13, 0, 0),
                Background = this.colorCollection[ran.Next(1, 10)],
                RecurrenceRule = "FREQ=DAILY;INTERVAL=1;COUNT=10",
                Id = 2,
                RecurrenceId = 1
            };

            this.RecursiveExceptionEvents.Add(changedEvent);

            var changedEvent1 = new SchedulerAppointment
            {
                Subject = "Scrum meeting - Changed Occurrence",
                StartTime = new DateTime(changedExceptionDate2.Year, changedExceptionDate2.Month, changedExceptionDate2.Day, 12, 0, 0),
                EndTime = new DateTime(changedExceptionDate2.Year, changedExceptionDate2.Month, changedExceptionDate2.Day, 13, 0, 0),
                Background = this.colorCollection[ran.Next(1, 10)],
                Id = 3,
                RecurrenceId = 1
            };

            this.RecursiveExceptionEvents.Add(changedEvent1);
        }

        #endregion
    }
}
