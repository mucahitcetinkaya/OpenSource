using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BooksApp.MVC.Areas.Admin.Models
{
    public class PublisherAddViewModel
    {
        public bool IsActive { get; set; }

        [DisplayName("Ad")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı en az {1} karakter uzunluğunda olmalıdır.")]
        [MaxLength(50, ErrorMessage = "{0} alanı en fazla {1} karakter uzunluğunda olmalıdır.")]
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        [DisplayName("Telefon")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamalıdır.")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Telefon numarası formata uygun olmalıdır.")]
        public string Phone { get; set; }
        
        public List<SelectListItem> Cities { get; set; }
    }
}