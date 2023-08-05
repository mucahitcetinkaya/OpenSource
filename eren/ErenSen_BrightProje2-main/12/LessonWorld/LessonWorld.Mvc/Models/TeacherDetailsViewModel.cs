

namespace LessonWorld.Mvc.Models
{
    public class TeacherDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string PhotoUrl { get; set; }
        public decimal Price { get; set; }
        public string LessonName { get; set; }
        public string LessonAbout { get; set; }
        public string LessonUrl { get; set; }
        public string SchoolName { get; set; }
        public string SchoolUrl { get; set; }
        public List<CategoryViewModel> Categories { get; set; }
        public string Description { get; set; }
    }
}
