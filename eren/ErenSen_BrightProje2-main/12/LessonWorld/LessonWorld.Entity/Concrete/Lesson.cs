using LessonWorld.Entity.Abstract;

namespace LessonWorld.Entity.Concrete
{
    public class Lesson:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int LessonTime { get; set; }
        public string About { get; set; }
        public bool IsHome { get; set; }

        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int? SchoolId { get; set; }
        public School School { get; set; }

        public List<LessonCategory> LessonCategories { get; set; }
    }
}
