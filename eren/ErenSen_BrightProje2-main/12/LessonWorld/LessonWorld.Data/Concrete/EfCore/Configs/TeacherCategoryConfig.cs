using LessonWorld.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonWorld.Data.Concrete.EfCore.Configs
{
    public class TeacherCategoryConfig : IEntityTypeConfiguration<TeacherCategory>
    {
        public void Configure(EntityTypeBuilder<TeacherCategory> builder)
        {
            builder.HasKey(tc => new { tc.TeacherId, tc.CategoryId });
            builder.HasData(new TeacherCategory { TeacherId = 1, CategoryId = 1 },
                            new TeacherCategory { TeacherId = 2, CategoryId = 1},
                            new TeacherCategory { TeacherId = 3, CategoryId = 2},
                            new TeacherCategory { TeacherId = 4, CategoryId = 2 },
                            new TeacherCategory { TeacherId = 5, CategoryId = 3 },

                            new TeacherCategory { TeacherId = 6, CategoryId = 3 },
                            new TeacherCategory { TeacherId = 7, CategoryId = 4 },
                            new TeacherCategory { TeacherId = 8, CategoryId = 4 },
                            new TeacherCategory { TeacherId = 9, CategoryId = 5 },
                            new TeacherCategory { TeacherId = 10, CategoryId = 5 }
                            );
        }

       
    }
}
