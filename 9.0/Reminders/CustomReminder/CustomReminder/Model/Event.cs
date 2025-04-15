using System.Collections.ObjectModel;

namespace CustomReminder
{
    public class Event
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public bool IsAllDay { get; set; }
        public string EventName { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public string StartTimeZone { get; set; } = string.Empty;
        public string EndTimeZone { get; set; } = string.Empty;
        public Brush? Color { get; set; }
        public object? RecurrenceId { get; set; } 
        public object? Id { get; set; }
        public string RecurrenceRule { get; set; } = string.Empty;
        public ObservableCollection<DateTime> RecurrenceExceptionDates { get; set; } = new ObservableCollection<DateTime>();
        public ObservableCollection<Reminder> Reminders { get; set; } = new ObservableCollection<Reminder>();
    }
}
