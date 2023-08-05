using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonWorld.Entity.Concrete
{
    public class TeacherCategory
    {
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
