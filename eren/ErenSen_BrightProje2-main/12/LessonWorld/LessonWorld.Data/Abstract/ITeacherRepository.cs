using LessonWorld.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonWorld.Data.Abstract
{
    public interface ITeacherRepository : IGenericRepository<Teacher>
    {
        Task<List<Teacher>> GetAllTeachersAsync(bool isDeleted, bool? isActive = null);
        Task<Teacher> GetTeacherByUrlAsync(string teacherUrl);

        Task<List<Teacher>> GetAllActiveTeachersAsync(string categoryUrl = null, string lessonUrl = null, string schoolUrl = null);

        Task CreateWithUrl(Teacher teacher);

    }
}
