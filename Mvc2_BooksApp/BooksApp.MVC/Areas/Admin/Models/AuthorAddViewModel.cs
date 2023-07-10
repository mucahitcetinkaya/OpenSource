using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BooksApp.Core;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BooksApp.MVC.Areas.Admin.Models
{
    public class AuthorAddViewModel
    {
        [DisplayName("Ad")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı en az {1} karakter uzunluğunda olmalıdır.")]
        [MaxLength(50, ErrorMessage = "{0} alanı en fazla {1} karakter uzunluğunda olmalıdır.")]
        public string FirstName { get; set; }

        [DisplayName("Soyad")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı en az {1} karakter uzunluğunda olmalıdır.")]
        [MaxLength(50, ErrorMessage = "{0} alanı en fazla {1} karakter uzunluğunda olmalıdır.")]
        public string LastName { get; set; }

        [DisplayName("Doğum Yılı")]
        public int BirthOfYear { get; set; } = 1900;

        [DisplayName("Hakkında")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı en az {1} karakter uzunluğunda olmalıdır.")]
        [MaxLength(1000, ErrorMessage = "{0} alanı en fazla {1} karakter uzunluğunda olmalıdır.")]
        public string About { get; set; }

        public bool IsActive { get; set; }

        public bool IsAlive { get; set; } = true;

        public string ImageUrl { get; set; } = "default-profile.jpg";

        public List<SelectListItem> Years { get; set; }
    }
}
