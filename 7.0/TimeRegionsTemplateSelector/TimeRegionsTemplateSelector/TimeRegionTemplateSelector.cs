using Syncfusion.Maui.Scheduler;

namespace TimeRegionsTemplateSelector
{
    public class TimeRegionTemplateSelector : DataTemplateSelector
    {
        public TimeRegionTemplateSelector()
        {
        }
        public DataTemplate TimeRegionsTemplate { get; set; }
        public DataTemplate TimeRegionsTemplate1 { get; set; }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var timeRegionDetails = item as SchedulerTimeRegion;
            if (timeRegionDetails.EnablePointerInteraction)
                return TimeRegionsTemplate;
            return TimeRegionsTemplate1;
        }
    }
}
