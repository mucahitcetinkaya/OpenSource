namespace BooksApp.MVC.Areas.Admin.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string AuthorName { get; set; }
        public string PublisherName { get; set; }
        public bool IsActive { get; set; }
    }
}
