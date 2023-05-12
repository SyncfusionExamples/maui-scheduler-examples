namespace ViewHeaderTemplateSelector
{
    public class ViewHeaderTemplateSelector : DataTemplateSelector
    {
        public ViewHeaderTemplateSelector()
        {
        }
        public DataTemplate NormalDateTemplate { get; set; }
        public DataTemplate TodayDateTemplate { get; set; }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var dateTime = (DateTime)item;
            if (dateTime.Date == DateTime.Today.Date)
                return TodayDateTemplate;
            else
                return NormalDateTemplate;
        }
    }
}
