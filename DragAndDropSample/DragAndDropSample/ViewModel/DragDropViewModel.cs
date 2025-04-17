using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragAndDropSample
{
    internal class DragDropViewModel
    {
        /// <summary>
        /// The subject collections.
        /// </summary>
        private List<string>? subjectCollection;

        /// <summary>
        /// The notes collection.
        /// </summary>
        private List<string>? noteCollection;

        /// <summary>
        /// The color collection
        /// </summary>
        private List<Brush>? colorCollection;

        /// <summary>
        /// Initializes a new instance of the <see cref="DragDropViewModel" /> class.
        /// </summary>
        public DragDropViewModel()
        {
            this.CreateSubjectCollection();
            this.CreateColorCollection();
            this.CreateNoteCollection();
            this.IntializeAppoitments();
        }

        /// <summary>
        /// Gets or sets appointments.
        /// </summary>
        public ObservableCollection<Meeting>? Events { get; set; }

        /// <summary>
        /// Method to create the note collection.
        /// </summary>
        private void CreateNoteCollection()
        {
            this.noteCollection = new List<string>();
            this.noteCollection.Add("Consulting firm laws with business advisers");
            this.noteCollection.Add("Execute Project Scope");
            this.noteCollection.Add("Project Scope & Deliverables");
            this.noteCollection.Add("Executive summary");
            this.noteCollection.Add("Try to reduce the risks");
            this.noteCollection.Add("Encourages the integration of mind, body, and spirit");
            this.noteCollection.Add("Execute Project Scope");
            this.noteCollection.Add("Project Scope & Deliverables");
            this.noteCollection.Add("Executive summary");
            this.noteCollection.Add("Try to reduce the risk");
        }

        /// <summary>
        /// Method to initialize the appointments.
        /// </summary>
        private void IntializeAppoitments()
        {
            this.Events = new ObservableCollection<Meeting>();
            Random randomTime = new Random();
            List<Point> randomTimeCollection = this.GettingTimeRanges();

            DateTime date;
            DateTime dateFrom = DateTime.Now.AddDays(-50);
            DateTime dateTo = DateTime.Now.AddDays(50);

            for (date = dateFrom; date < dateTo; date = date.AddDays(1))
            {
                for (int additionalAppointmentIndex = 0; additionalAppointmentIndex < 1; additionalAppointmentIndex++)
                {
                    var meeting = new Meeting();
                    int hour = randomTime.Next((int)randomTimeCollection[additionalAppointmentIndex].X, (int)randomTimeCollection[additionalAppointmentIndex].Y);
                    meeting.From = new DateTime(date.Year, date.Month, date.Day, hour, 0, 0);
                    meeting.To = meeting.From.AddHours(1);
                    if (subjectCollection != null && colorCollection != null)
                    {
                        meeting.EventName = subjectCollection[randomTime.Next(9)];
                        meeting.Background = colorCollection[randomTime.Next(10)];
                    }

                    meeting.IsAllDay = false;
                    meeting.StartTimeZone = TimeZoneInfo.Local;
                    meeting.EndTimeZone = TimeZoneInfo.Local;
                    this.Events.Add(meeting);
                }
            }
        }

        /// <summary>
        /// Method to create the subject collection.
        /// </summary>
        private void CreateSubjectCollection()
        {
            this.subjectCollection = new List<string>();
            this.subjectCollection.Add("General Meeting");
            this.subjectCollection.Add("Plan Execution");
            this.subjectCollection.Add("Project Plan");
            this.subjectCollection.Add("Consulting");
            this.subjectCollection.Add("Performance Check");
            this.subjectCollection.Add("Support");
            this.subjectCollection.Add("Development Meeting");
            this.subjectCollection.Add("Scrum");
            this.subjectCollection.Add("Project Completion");
            this.subjectCollection.Add("Release updates");
            this.subjectCollection.Add("Performance Check");
        }

        /// <summary>
        /// Method to get timing range.
        /// </summary>
        /// <returns>return time collection</returns>
        private List<Point> GettingTimeRanges()
        {
            List<Point> randomTimeCollection = new List<Point>();
            randomTimeCollection.Add(new Point(9, 11));
            randomTimeCollection.Add(new Point(12, 14));
            randomTimeCollection.Add(new Point(15, 17));

            return randomTimeCollection;
        }

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
    }
}
