using System.Collections.ObjectModel;

namespace CustomReminder
{
    public class Event
    {
        public Event()
        {

        }

        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public bool IsAllDay { get; set; }
        public string EventName { get; set; }
        public string Notes { get; set; }
        public string StartTimeZone { get; set; }
        public string EndTimeZone { get; set; }
        public Brush Color { get; set; }
        public object RecurrenceId { get; set; }
        public object Id { get; set; }
        public string RecurrenceRule { get; set; }
        public ObservableCollection<DateTime> RecurrenceExceptionDates { get; set; }
        public ObservableCollection<Reminder> Reminders { get; set; }
    }
}
