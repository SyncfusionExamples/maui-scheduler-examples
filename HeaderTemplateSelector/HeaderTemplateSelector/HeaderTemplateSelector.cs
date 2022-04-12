using Syncfusion.Maui.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeaderTemplateSelector
{
    public class HeaderTemplateSelector : DataTemplateSelector
    {
        public HeaderTemplateSelector()
        {
        }
        public DataTemplate TodayDatesTemplate { get; set; }
        public DataTemplate NormaldatesTemplate { get; set; }
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
