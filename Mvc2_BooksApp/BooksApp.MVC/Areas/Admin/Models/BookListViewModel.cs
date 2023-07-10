namespace BooksApp.MVC.Areas.Admin.Models
{
    public class BookListViewModel
    {
        public List<BookViewModel> BookViewModelList { get; set; }
        public string SourceAction { get; set; }
    }
}
