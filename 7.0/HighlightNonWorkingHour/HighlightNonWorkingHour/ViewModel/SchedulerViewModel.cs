using Syncfusion.Maui.Scheduler;
using System.Collections.ObjectModel;

namespace HighlightNonWorkingHour
{
    public class SchedulerViewModel
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SchedulerViewModel" /> class.
        /// </summary>
        public SchedulerViewModel()
        {
            this.GenerateTimeRegions();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets time regions.
        /// </summary>
        public ObservableCollection<SchedulerTimeRegion> TimeRegions { get; set; } = new ObservableCollection<SchedulerTimeRegion>();

        #endregion

        #region Methods

        /// <summary>
        /// Method to get special time regions.
        /// </summary>
        private void GenerateTimeRegions()
        {
            var currentDate = DateTime.Now.AddMonths(-5);
            this.TimeRegions = new ObservableCollection<SchedulerTimeRegion>();

            this.TimeRegions.Add(new SchedulerTimeRegion()
            {
                StartTime = new DateTime(currentDate.Year, currentDate.Month, 1, 0, 0, 0),
                EndTime = new DateTime(currentDate.Year, currentDate.Month, 1, 9, 0, 0),
                Background = new SolidColorBrush(Colors.LightGray.WithAlpha(0.3f)),
                EnablePointerInteraction = false,
                RecurrenceRule = "FREQ=DAILY;INTERVAL=1",
            });

            this.TimeRegions.Add(new SchedulerTimeRegion()
            {
                StartTime = new DateTime(currentDate.Year, currentDate.Month, 1, 18, 0, 0),
                EndTime = new DateTime(currentDate.Year, currentDate.Month, 1, 23, 59, 59),
                Background = new SolidColorBrush(Colors.LightGray.WithAlpha(0.3f)),
                EnablePointerInteraction = false,
                RecurrenceRule = "FREQ=DAILY;INTERVAL=1",
            });
        }

        #endregion
    }
}
