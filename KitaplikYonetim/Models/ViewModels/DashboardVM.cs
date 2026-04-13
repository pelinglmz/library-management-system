using KitaplikYonetim.Models.Entities;

namespace KitaplikYonetim.Models.ViewModels
{
    public class DashboardVM
    {
        public int BookCount { get; set; }
        public int AuthorCount { get; set; }
        public int CategoryCount { get; set; }

        public int PublisherCount { get; set; }

        public List<Book> RecentBooks { get; set; } = new List<Book>();
    }
}