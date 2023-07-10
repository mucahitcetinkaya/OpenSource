using BooksApp.Entity.Concrete;

namespace BooksApp.MVC.Areas.Admin.Models
{
    public class UserUpdateViewModel
    {
        public User User { get; set; }
        public List<Role> Roles { get; set; }
        public IList<string> SelectedRoles { get; set; }
    }
}
