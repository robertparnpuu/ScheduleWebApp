
namespace Domain.Repos {
    public interface IFilteredRepo {
        public string CurrentFilter { get; set; }
        public string SearchString { get; set; }
    }
}
