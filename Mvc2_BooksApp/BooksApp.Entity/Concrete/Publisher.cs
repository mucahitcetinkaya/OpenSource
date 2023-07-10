using BooksApp.Entity.About;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.Entity.Concrete
{
    public class Publisher : BaseEntity
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; } = "Türkiye";
        public string Phone { get; set; }
        public string Url { get; set; }
        public List<Book> Books { get; set; }
    }
}
