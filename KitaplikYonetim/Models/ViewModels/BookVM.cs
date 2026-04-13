using Microsoft.AspNetCore.Mvc.Rendering;
using KitaplikYonetim.Models.Entities;

namespace KitaplikYonetim.Models.ViewModels
{
    public class BookVM
    {
        public Book Book { get; set; } = new Book(); // Kitap verisi

        // Dropdown listeleri (Select-Option için)
        public IEnumerable<SelectListItem>? CategoryList { get; set; }
        public IEnumerable<SelectListItem>? AuthorList { get; set; }
        public IEnumerable<SelectListItem>? PublisherList { get; set; }
    }
}


