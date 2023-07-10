using BooksApp.Entity.Concrete;

namespace BooksApp.MVC.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string AuthorName { get; set; }
        public string AuthorUrl { get; set; }
        public string PublisherName { get; set; }
        public string PublisherUrl { get; set;}
        public List<CategoryViewModel> Categories { get; set; }
    }
}
