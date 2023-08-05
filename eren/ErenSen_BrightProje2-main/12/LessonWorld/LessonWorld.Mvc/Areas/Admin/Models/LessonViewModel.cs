namespace LessonWorld.Mvc.Areas.Admin.Models
{
    public class LessonViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string TeacherName { get; set; }
        public string SchoolName { get; set; }
        public bool IsActive { get; set; }
    }
}
