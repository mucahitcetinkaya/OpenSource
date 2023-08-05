using LessonWorld.Business.Abstract;
using LessonWorld.Data.Abstract;
using LessonWorld.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonWorld.Business.Concrete
{
    public class SchoolManager : ISchoolService
    {
        private readonly ISchoolRepository _schoolRepository;

        public SchoolManager(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }
        public async Task CreateAsync(School school)
        {
            await _schoolRepository.CreateAsync(school);
        }

        public  void Delete(School school)
        {
            _schoolRepository.Delete(school);
        }

        public async Task<List<School>> GetAllAsync()
        {
           var result =await _schoolRepository.GetAllAsync();
            return result;
        }

        public async Task<List<School>> GetAllSchoolsAsync(bool isDeleted, bool? isActive = null)
        {
           var result=await _schoolRepository.GetAllSchoolsAsync(isDeleted, isActive);
            return result;
        }

        public async Task<School> GetByIdAsync(int? id)
        {
            var result=await _schoolRepository.GetByIdAsync(id);
            return result;
        }

        public void Update(School school)
        {
            _schoolRepository.Update(school);
        }
    }
}
