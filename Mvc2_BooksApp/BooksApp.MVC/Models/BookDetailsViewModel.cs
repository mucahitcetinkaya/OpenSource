using System;
namespace BooksApp.MVC.Models
{
	public class BookDetailsViewModel
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string AuthorName { get; set; }
        public string AuthorAbout { get; set; }
        public string AuthorUrl { get; set; }
        public string PublisherName { get; set; }
        public string PublisherUrl { get; set; }
        public List<CategoryViewModel> Categories { get; set; }
        public int EditionYear { get; set; }
        public int EditionNumber { get; set; }
        public int Stock { get; set; }
        public int PageCount { get; set; }
        public string Description { get; set; }
    }
}

