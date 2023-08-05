﻿namespace LessonWorld.Mvc.Areas.Admin.Models
{
    public class LessonDeleteViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TeacherName { get; set; }
        public string SchoolName { get; set; }
        public decimal Price { get; set; }
        public bool IsHome { get; set; }
        public bool IsActive { get; set; }
    }
}
