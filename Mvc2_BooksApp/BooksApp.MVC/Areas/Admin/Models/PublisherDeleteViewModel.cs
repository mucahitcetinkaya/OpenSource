using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BooksApp.MVC.Areas.Admin.Models
{
	public class PublisherDeleteViewModel
	{
        public int Id { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string Url { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}

