using System.Globalization;

namespace AgendaMonthHeaderTemplate
{
    internal class MonthToImageConvertor : IValueConverter
    {
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var monthName = String.Format("{0:MMMM}", value).ToLower();
                return monthName + ".png";
            }

            return null;
        }

        public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
