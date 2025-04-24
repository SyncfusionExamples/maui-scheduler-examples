using Syncfusion.Maui.Scheduler;

namespace MonthCellTemplateSelector
{
    public class MonthCellTemplateSelector : DataTemplateSelector
    {
        public MonthCellTemplateSelector()
        {
        }
        public DataTemplate NormalDateTemplate { get; set; } = new DataTemplate();
        public DataTemplate TodayDateTemplate { get; set; } = new DataTemplate();
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var monthCellDetails = item as SchedulerMonthCellDetails;
            if (monthCellDetails == null)
            {
                return new DataTemplate();
            }
            if (monthCellDetails.DateTime.Date == DateTime.Today.Date)
                return TodayDateTemplate;
            else
                return NormalDateTemplate;
        }
    }
}
