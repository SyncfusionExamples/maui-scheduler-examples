using Microsoft.Maui.Controls;
using System;
using System.ComponentModel;

namespace AppointmentSelectionBackground
{
    public class Event : INotifyPropertyChanged
    {
        private DateTime from, to;
        private string eventName;
        private bool isAllDay;
        private TimeZoneInfo startTimeZone, endTimeZone;
        private Brush background;
        private string notes;

        /// <summary>
        /// Property changed event handler
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the value to display the start date.
        /// </summary>
        public DateTime From
        {
            get { return from; }
            set
            {
                from = value;
                this.RaiseOnPropertyChanged(nameof(From));
            }
        }

        /// <summary>
        /// Gets or sets the value to display the end date.
        /// </summary>
        public DateTime To
        {
            get { return to; }
            set
            {
                to = value;
                this.RaiseOnPropertyChanged(nameof(To));
            }
        }

        /// <summary>
        /// Gets or sets the value indicating whether the appointment is all-day or not.
        /// </summary>
        public bool IsAllDay
        {
            get { return isAllDay; }
            set
            {
                isAllDay = value;
                this.RaiseOnPropertyChanged(nameof(IsAllDay));
            }
        }

        /// <summary>
        /// Gets or sets the value to display the subject.
        /// </summary>
        public string EventName
        {
            get { return eventName; }
            set
            {
                eventName = value;
                this.RaiseOnPropertyChanged(nameof(EventName));
            }
        }

        /// <summary>
        /// Gets or sets the value to display the notes.
        /// </summary>
        public string Notes
        {
            get { return notes; }
            set
            {
                notes = value;
                this.RaiseOnPropertyChanged(nameof(Notes));
            }
        }

        /// <summary>
        /// Gets or sets the value to display the start time zone.
        /// </summary>
        public TimeZoneInfo StartTimeZone
        {
            get { return startTimeZone; }
            set
            {
                startTimeZone = value;
                this.RaiseOnPropertyChanged(nameof(StartTimeZone));
            }
        }

        /// <summary>
        /// Gets or sets the value to display the end time zone.
        /// </summary>
        public TimeZoneInfo EndTimeZone
        {
            get { return endTimeZone; }
            set
            {
                endTimeZone = value;
                this.RaiseOnPropertyChanged(nameof(EndTimeZone));
            }
        }

        /// <summary>
        /// Gets or sets the value to display the background.
        /// </summary>
        public Brush Background
        {
            get { return background; }
            set
            {
                background = value;
                this.RaiseOnPropertyChanged(nameof(Background));
            }
        }

        /// <summary>
        /// Invoke method when property changed.
        /// </summary>
        /// <param name="propertyName">property name</param>
        private void RaiseOnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}