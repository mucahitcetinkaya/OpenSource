using LessonWorld.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonWorld.Entity.Concrete
{
    public class Teacher:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BirthOfYear { get; set; }
        public bool IsAlive { get; set; }
        public string Url { get; set; }
        public string About { get; set; }
        public string PhotoUrl { get; set; }

        public List<Lesson> Lessons { get; set; }
      


    }
}
