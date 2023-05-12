namespace AgendaViewTemplateSelector
{
    public class AgendaViewTemplateSelector : DataTemplateSelector
    {
        public AgendaViewTemplateSelector()
        {
        }
        public DataTemplate NormalDateTemplate { get; set; }
        public DataTemplate TodayDateTemplate { get; set; }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var dateTime = (DateTime)item;
            if (dateTime.Month == DateTime.Today.Month)
                return TodayDateTemplate;
            else
                return NormalDateTemplate;
        }
    }
}
