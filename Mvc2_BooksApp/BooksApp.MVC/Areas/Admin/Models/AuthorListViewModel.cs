namespace BooksApp.MVC.Areas.Admin.Models
{
    public class AuthorListViewModel
    {
        public List<AuthorViewModel> AuthorViewModelList { get; set; }
        public string SourceAction { get; set; }
    }
}
