using LessonWorld.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonWorld.Business.Abstract
{
    public interface ITeacherService
    {
        Task<Teacher> GetByIdAsync(int? id);
        Task<List<Teacher>> GetAllAsync();
        Task CreateAsync(Teacher teacher);
        void Update(Teacher teacher);
        void Delete(Teacher teacher);

        Task<List<Teacher>> GetAllTeachersAsync(bool isDeleted, bool? isActive = null);
        Task<Teacher> GetTeacherByUrlAsync(string teacherUrl);

        Task<List<Teacher>> GetAllActiveTeachersAsync(string categoryUrl = null ,string lessonUrl=null, string schoolUrl = null);

        Task CreateWithUrl(Teacher teacher);
    }
}
