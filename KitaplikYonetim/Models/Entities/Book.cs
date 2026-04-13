using System.ComponentModel.DataAnnotations.Schema;

namespace KitaplikYonetim.Models.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? ImagePath { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; } // ? ekle

        public int AuthorId { get; set; }
        public Author? Author { get; set; } // ? ekle

        public int PublisherId { get; set; } // 4. tablo (Yayınevi)
        public Publisher? Publisher { get; set; } // ? ekle
    }
}