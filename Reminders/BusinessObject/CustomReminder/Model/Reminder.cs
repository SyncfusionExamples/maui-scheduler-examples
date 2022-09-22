using System.ComponentModel;

namespace CustomReminder
{
    public class Reminder : INotifyPropertyChanged
    {
        bool isDismissed;
        TimeSpan timeBeforeStart;

        public bool IsDismissed
        {
            get => isDismissed;

            set
            {
                if (isDismissed != value)
                {
                    isDismissed = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsDismissed)));
                }
            }
        }
        public TimeSpan TimeBeforeStart
        {
            get
            {
                return timeBeforeStart;
            }
            set
            {
                if (timeBeforeStart != value)
                {
                    timeBeforeStart = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TimeBeforeStart)));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
