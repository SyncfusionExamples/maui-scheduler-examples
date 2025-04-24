using Syncfusion.Maui.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeRegionsTemplateSelector
{
    public class TimeRegionTemplateSelector : DataTemplateSelector
    {
        public TimeRegionTemplateSelector()
        {
        }
        public DataTemplate TimeRegionsTemplate { get; set; } = new DataTemplate();
        public DataTemplate TimeRegionsTemplate1 { get; set; } = new DataTemplate();
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var timeRegionDetails = item as SchedulerTimeRegion;
            if (timeRegionDetails == null)
                return new DataTemplate();
            if (timeRegionDetails.EnablePointerInteraction)
                return TimeRegionsTemplate;
            return TimeRegionsTemplate1;
        }
    }
}
