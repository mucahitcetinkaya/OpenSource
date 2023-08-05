using LessonWorld.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonWorld.Business.Abstract
{
    public interface ISchoolService
    {
        Task<School> GetByIdAsync(int? id);
        Task<List<School>> GetAllAsync();
        Task CreateAsync(School school);
        void Update(School school);
        void Delete(School school);

        Task<List<School>> GetAllSchoolsAsync(bool isDeleted, bool? isActive = null);
    }
}
