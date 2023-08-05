using LessonWorld.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonWorld.Data.Abstract
{
    public interface ISchoolRepository : IGenericRepository<School>
    {
        Task<List<School>> GetAllSchoolsAsync(bool isDeleted, bool? isActive = null);

    }
}
