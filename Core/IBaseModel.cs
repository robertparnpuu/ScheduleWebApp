namespace Core
{
    public interface IBaseModel
    {
        public string SortOrder { get; }
        public string CurrentSort { get; }
        public string CurrentFilter { get; }
        public string SearchString { get; }
        public int? PageIndex { get; }
        public string PageUrl { get; }
    }
}
