namespace BooksApp.MVC.Areas.Admin.Models
{
    public class BookDeleteViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public string PublisherName { get; set; }
        public decimal Price { get; set; }
        public int EditionYear { get; set; }
        public int EditionNumber { get; set; }
        public bool IsHome { get; set; }
        public bool IsActive { get; set; }
    }
}
