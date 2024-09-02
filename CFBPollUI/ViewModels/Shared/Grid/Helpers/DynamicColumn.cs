namespace CFBPollUI.ViewModels.Shared.Grid.Helpers
{
    public class DynamicColumn
    {
        public bool Filterable { get; set; }
        public string Format { get; set; } = string.Empty;
        public bool IsCheckboxColumn { get; set; }
        public bool IsCheckmarkColumn { get; set; }
        public bool IsHtmlColumn { get; set; } = false;
        public bool IsButtonColumn { get; set; } = false;
        public bool IsHidden { get; set; }
        public byte Position { get; set; }
        public string PropertyName { get; set; } = string.Empty;
        public bool Sortable { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}
