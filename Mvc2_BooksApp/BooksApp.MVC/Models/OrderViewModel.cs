﻿using BooksApp.Entity.Concrete;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BooksApp.MVC.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        [DisplayName("Ad")]
        [Required(ErrorMessage = "{0} alanı boş bırakılmamalıdır.")]
        public string FirstName { get; set; }

        [DisplayName("Soyad")]
        [Required(ErrorMessage = "{0} alanı boş bırakılmamalıdır.")]
        public string LastName { get; set; }

        [DisplayName("Adres")]
        [Required(ErrorMessage = "{0} alanı boş bırakılmamalıdır.")]
        public string Address { get; set; }

        [DisplayName("Şehir")]
        [Required(ErrorMessage = "{0} alanı boş bırakılmamalıdır.")]
        public string City { get; set; }

        [DisplayName("Telefon Numarası")]
        [Required(ErrorMessage = "{0} alanı boş bırakılmamalıdır.")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "{0} alanı boş bırakılmamalıdır.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public DateTime OrderDate { get; set; }
        public CartViewModel Cart { get; set; }

        //Kredi Kartı bilgileri
        [DisplayName("Kartın üzerindeki ad soyad")]
        [Required(ErrorMessage = "{0} alanı boş bırakılmamalıdır.")]
        public string CardName { get; set; }

        [DisplayName("Kart Numarası")]
        [Required(ErrorMessage = "{0} alanı boş bırakılmamalıdır.")]
        public string CardNumber { get; set; }

        [DisplayName("Geçerlilik Tarihi Yıl")]
        [Required(ErrorMessage = "{0} alanı boş bırakılmamalıdır.")]
        public string ExpirationYear { get; set; }

        [DisplayName("Geçerlilik Tarihi Ay")]
        [Required(ErrorMessage = "{0} alanı boş bırakılmamalıdır.")]
        public string ExpirationMonth { get; set; }

        [DisplayName("Cvc No")]
        [Required(ErrorMessage = "{0} alanı boş bırakılmamalıdır.")]
        public string Cvc { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public string OrderStatus { get; set; }
        public decimal? TotalPrice()
        {
            return OrderItems.Sum(ci => ci.Price * ci.Quantity);
        }

    }
}
