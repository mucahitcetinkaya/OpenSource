using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonWorld.Entity.Concrete.ComplexTypes
{
    public enum OrderStatus
    {
        [Display(Name = "Kaydınız alındı.")]
        Received = 0,
        [Display(Name = "Kayıt oluşturuluyor.")]
        Preparing = 1,
        [Display(Name = "Kaydınız Tamamlanıyor.")]
        Sent = 2,
        [Display(Name = "Kaydınız tamamlandı.")]
        Delivered = 3
    }
}
