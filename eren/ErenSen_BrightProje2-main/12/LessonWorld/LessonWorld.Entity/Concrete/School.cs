using LessonWorld.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonWorld.Entity.Concrete
{
    public class School :BaseEntity
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; } = "Türkiye";
        public string Phone { get; set; }
        public string Url { get; set; }
        public List<Lesson> Lessons { get; set; }
        public List<Teacher> Teachers { get; set; }

    }
}
