using Syncfusion.Maui.Scheduler;

namespace HeaderTemplateSelector
{
    public class HeaderTemplateSelector : DataTemplateSelector
    {
        public HeaderTemplateSelector()
        {
        }
        public DataTemplate TodayDatesTemplate { get; set; } = new DataTemplate();
        public DataTemplate NormaldatesTemplate { get; set; } = new DataTemplate();
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var headerDetails = item as SchedulerHeaderDetails;
            if (headerDetails != null)
            {
                if (headerDetails.StartDate.Date <= DateTime.Now.Date && headerDetails.EndDate >= DateTime.Now.Date)
                    return TodayDatesTemplate;
            }
            return NormaldatesTemplate;
        }
    }
}
