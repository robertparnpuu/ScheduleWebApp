
namespace Domain.Repos {
    public interface IPagedRepo {
        public int? PageIndex { get; set; }
        public int TotalPages { get; }
        public bool HasNextPage { get; }
        public bool HasPreviousPage { get; }
        public int PageSize { get; set; }
    }
}
