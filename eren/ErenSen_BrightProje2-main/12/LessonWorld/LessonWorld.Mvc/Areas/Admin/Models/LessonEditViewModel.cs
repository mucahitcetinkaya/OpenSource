using LessonWorld.Entity.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LessonWorld.Mvc.Areas.Admin.Models
{
    public class LessonEditViewModel
    {
        public LessonEditViewModel()
        {
            SelectedCategoryIds = new List<int>();
        }
        public int Id { get; set; }

        [DisplayName("Aktif mi?")]
        public bool IsActive { get; set; }

        [DisplayName("Silinmiş mi?")]
        public bool IsDeleted { get; set; }

        [DisplayName("Ad")]
        [Required(ErrorMessage ="{0} alanı boş bırakılmamalıdır.")]
        [MinLength(3,ErrorMessage = "{0} alanının uzunluğu {1} karakterden az olmamalalıdır.")]
        [MaxLength(100, ErrorMessage = "{0} alanının uzunluğu {1} karakterden fazla olmamalıdır.")]
        public string Name { get; set; }

        [DisplayName("Açıklama")]
        [Required(ErrorMessage = "{0} alanı boş bırakılmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanının uzunluğu {1} karakterden az olmamalalıdır.")]
        [MaxLength(1000, ErrorMessage = "{0} alanının uzunluğu {1} karakterden fazla olmamalıdır.")]
        public string Description { get; set; }

        [DisplayName("Resim")]
        public IFormFile ImageFile { get; set; }
        public string ImageUrl { get; set; }

        [DisplayName("Fiyat")]
        [Required(ErrorMessage = "{0} alanı boş bırakılmamalıdır.")]
        public decimal Price { get; set; } = 0;

        [DisplayName("Ana Sayfa")]
        public bool IsHome { get; set; }
        public int? TeacherId { get; set; }
        public int? SchoolId { get; set; }

        public List<SelectListItem> YearList { get; set; }

        [DisplayName("Öğretmenler")]
        public List<SelectListItem> TeacherList { get; set; }

        [DisplayName("Okullar")]
        public List<SelectListItem> SchoolList { get; set; }

        [DisplayName("Kategoriler")]
        public List<CategoryViewModel> CategoryList { get; set; }

        public List<int> SelectedCategoryIds { get; set; } 
    }
}
