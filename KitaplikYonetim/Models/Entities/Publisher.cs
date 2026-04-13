namespace KitaplikYonetim.Models.Entities
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // Bir yayınevinin birden fazla kitabı olabilir (1-M)
        public List<Book> Books { get; set; }
    }
}