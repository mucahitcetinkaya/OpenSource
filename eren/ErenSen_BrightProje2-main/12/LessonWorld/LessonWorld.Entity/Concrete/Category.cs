using LessonWorld.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonWorld.Entity.Concrete
{
    public class Category :BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public List<LessonCategory>LessonCategories { get; set; }

    }
}
