namespace KitaplikYonetim.Models.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        // Bir yazarın birden fazla kitabı olabilir (1-M)
        public List<Book> Books { get; set; }
    }
}