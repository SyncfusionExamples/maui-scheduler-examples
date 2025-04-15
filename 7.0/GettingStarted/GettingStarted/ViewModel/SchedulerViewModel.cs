using Syncfusion.Maui.Scheduler;
using System.Collections.ObjectModel;

namespace GettingStarted
{
    public class SchedulerViewModel
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SchedulerViewModel" /> class.
        /// </summary>
        public SchedulerViewModel()
        {
            this.GenerateAppointments();
            this.DisplayDate = DateTime.Now.Date.AddHours(8).AddMinutes(50);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the schedule display date.
        /// </summary>
        public DateTime DisplayDate { get; set; }

        /// <summary>
        /// Gets or sets the appointments.
        /// </summary>
        public ObservableCollection<SchedulerAppointment>? Events { get; set; }

        #endregion

        #region Method

        /// <summary>
        /// Method to generate the appointments.
        /// </summary>
        private void GenerateAppointments()
        {
            this.Events = new ObservableCollection<SchedulerAppointment>();

            //Adding the schedule appointments in the schedule appointment collection.
            this.Events.Add(new SchedulerAppointment
            {
                StartTime = DateTime.Now.Date.AddHours(10),
                EndTime = DateTime.Now.Date.AddHours(11),
                Subject = "Client Meeting",
                Background = new SolidColorBrush(Color.FromArgb("#FF8B1FA9")),
            });

            this.Events.Add(new SchedulerAppointment
            {
                StartTime = DateTime.Now.Date.AddDays(1).AddHours(13),
                EndTime = DateTime.Now.Date.AddDays(1).AddHours(14),
                Subject = "GoToMeeting",
                Background = new SolidColorBrush(Color.FromArgb("#FFD20100")),
            });

            this.Events.Add(new SchedulerAppointment
            {
                StartTime = DateTime.Now.Date.AddDays(-1).AddHours(9),
                EndTime = DateTime.Now.Date.AddDays(-1).AddHours(10),
                Subject = "Generate Report",
                Background = new SolidColorBrush(Color.FromArgb("#FFFC571D")),
            });

            this.Events.Add(new SchedulerAppointment
            {
                StartTime = DateTime.Now.Date.AddDays(2).AddHours(14),
                EndTime = DateTime.Now.Date.AddDays(2).AddHours(15),
                Subject = "Generate Report",
                Background = new SolidColorBrush(Color.FromArgb("#FF36B37B")),
            });

            this.Events.Add(new SchedulerAppointment
            {
                StartTime = DateTime.Now.Date.AddDays(-2).AddHours(4),
                EndTime = DateTime.Now.Date.AddDays(-2).AddHours(5),
                Subject = "Plan Execution",
                Background = new SolidColorBrush(Color.FromArgb("#FFE47C73"))
            });

            this.Events.Add(new SchedulerAppointment
            {
                StartTime = DateTime.Now.Date.AddDays(0).AddHours(5),
                EndTime = DateTime.Now.Date.AddDays(0).AddHours(6),
                Subject = "Consulting",
                Background = new SolidColorBrush(Color.FromArgb("#FF85461E")),
            });

            this.Events.Add(new SchedulerAppointment
            {
                StartTime = DateTime.Now.Date.AddDays(1).AddHours(9),
                EndTime = DateTime.Now.Date.AddDays(1).AddHours(10),
                Subject = "Performance Check",
                Background = new SolidColorBrush(Color.FromArgb("#FF3D4FB5")),
            });

            this.Events.Add(new SchedulerAppointment
            {
                StartTime = DateTime.Now.Date.AddDays(3).AddHours(17),
                EndTime = DateTime.Now.Date.AddDays(3).AddHours(18),
                Subject = "Project Plan",
                Background = new SolidColorBrush(Color.FromArgb("#FF0F8644")),
            });

            this.Events.Add(new SchedulerAppointment
            {
                StartTime = DateTime.Now.Date.AddDays(0).AddHours(17),
                EndTime = DateTime.Now.Date.AddDays(0).AddHours(18),
                Subject = "Consulting",
                Background = new SolidColorBrush(Color.FromArgb("#FF636363")),
                IsAllDay = true
            });
        }

        #endregion
    }
}
