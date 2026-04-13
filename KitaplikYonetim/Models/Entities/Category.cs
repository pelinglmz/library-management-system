namespace KitaplikYonetim.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // Bir kategoride birden fazla kitap olabilir (1-M)
        public List<Book> Books { get; set; }
    }
}